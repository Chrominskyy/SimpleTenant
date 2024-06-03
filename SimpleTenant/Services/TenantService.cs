using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Repositories;

namespace SimpleTenant.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IBaseMapper<Tenant, TenantPostDto> _tenantPostDtoTenantMapper;
    
    public TenantService(ITenantRepository tenantRepository, IBaseMapper<
        Tenant, TenantPostDto> tenantPostDtoTenantMapper)
    {
        _tenantRepository = tenantRepository;
        _tenantPostDtoTenantMapper = tenantPostDtoTenantMapper;
    }
    
    public async Task<Guid> CreateTenant(TenantPostDto tenant)
    {
        var tenantDto = _tenantPostDtoTenantMapper.ToEntity(tenant);
        return await _tenantRepository.AddAsync<Tenant>(tenantDto);
    }

    public async Task<Tenant?> GetTenantById(Guid tenantId)
    {
        return await _tenantRepository.GetByIdAsync<Tenant>(tenantId);
    }

    public async Task<IEnumerable<Tenant>> GetAllTenants()
    {
        throw new NotImplementedException();
    }

    public async Task<Tenant> UpdateTenant(Tenant tenant)
    {
        return await _tenantRepository.UpdateAsync<Tenant>(tenant);
    }

    public async Task<bool> DeleteTenant(Guid tenantId)
    {
        return await _tenantRepository.DeleteAsync<Tenant>(tenantId);
    }
}