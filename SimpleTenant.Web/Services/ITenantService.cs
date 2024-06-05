using SimpleTenant.Models;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Web.Services;

public interface ITenantService
{
    public Task<IEnumerable<Tenant>> GetTenantsAsync();
    
    public Task<Tenant> GetTenantByIdAsync(Guid id);
    
    public Task<Tenant> PostTenantAsync(TenantPostDto tenant);
    
    public Task<Tenant> PutTenantAsync(TenantPutDto tenant);
    
    public Task<Tenant> DeleteTenantAsync(Guid id);

    public Task<bool> DeactivateTenantAsync(Guid id);
    
    public Task<bool> ActivateTenantAsync(Guid id);
}