using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Mappers.Tenant;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Web.Services;
using SimpleTenant.Web.Clients;

namespace SimpleTenant.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        
        builder.Services.AddScoped<ITenantService, TenantService>();
        builder.Services.AddScoped<IApiClient, TenantApiClient>();
        builder.Services.AddScoped<IBaseMapper<Tenant, TenantPostDto>, TenantPostDtoTenantMapper>();
        builder.Services.AddScoped<IBaseMapper<Tenant, TenantPutDto>, TenantPutDtoTenantMapper>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}