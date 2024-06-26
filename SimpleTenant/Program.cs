using Chrominsky.Utils.Mappers.Base;
using Chrominsky.Utils.Repositories.ObjectVersioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleTenant.Contexts;
using SimpleTenant.Mappers.Tenant;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Repositories;
using SimpleTenant.Services;
using StackExchange.Redis;
using ObjectVersioningRepository = SimpleTenant.Repositories.ObjectVersioningRepository;

namespace SimpleTenant;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleTenant API", Version = "v1" });
        });
        
        builder.Services.AddDbContext<TenantDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbContext")));
        
        builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
            return ConnectionMultiplexer.Connect(configuration);
        });
        builder.Services.AddScoped<ITenantService, TenantService>();
        builder.Services.AddScoped<ITenantRepository, TenantRepository>();
        builder.Services.AddScoped<IBaseMapper<Tenant, TenantPostDto>, TenantPostDtoTenantMapper>();
        builder.Services.AddScoped<IBaseMapper<Tenant, TenantPutDto>, TenantPutDtoTenantMapper>();
        builder.Services.AddScoped<IObjectVersioningRepository, ObjectVersioningRepository>();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleTenant API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}