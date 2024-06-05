using Chrominsky.Utils.Enums;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Web.Clients;

namespace SimpleTenant.Web.Services;

public class TenantService : ITenantService
{
    private readonly IApiClient _tenantApiClient;

    public TenantService(IApiClient tenantApiClient)
    {
        _tenantApiClient = tenantApiClient;
    }
    
    public async Task<IEnumerable<Tenant>> GetTenantsAsync()
    {
        var response = await _tenantApiClient.GetAsync<IEnumerable<Tenant>>("/api/tenants");
        return response;
    }

    public async Task<Tenant> GetTenantByIdAsync(Guid id)
    {
        var response = await _tenantApiClient.GetAsync<Tenant>($"/api/tenants/{id}");
        return response;
    }

    public async Task<Tenant> PostTenantAsync(TenantPostDto tenant)
    {
        throw new NotImplementedException();
    }

    public async Task<Tenant> PutTenantAsync(TenantPutDto tenant)
    {
        throw new NotImplementedException();
    }

    public async Task<Tenant> DeleteTenantAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeactivateTenantAsync(Guid id)
    {
        var tenantPutDto = new TenantPutDto { Id = id, Status = DatabaseEntityStatus.Inactive, UpdatedBy = "TestUser" };
        var response = await _tenantApiClient.PutAsync<Tenant, TenantPutDto>("/api/tenants", tenantPutDto);
        return response.Id == id;
    }
    
    public async Task<bool> ActivateTenantAsync(Guid id)
    {
        var tenantPutDto = new TenantPutDto { Id = id, Status = DatabaseEntityStatus.Active, UpdatedBy = "TestUser" };
        var response = await _tenantApiClient.PutAsync<Tenant, TenantPutDto>("/api/tenants", tenantPutDto);
        return response.Id == id;
    }
}