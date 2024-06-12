using Chrominsky.Utils.Mappers.Base;
using Chrominsky.Utils.Models;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Repositories;

namespace SimpleTenant.Services;

/// <inheritdoc/>
public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IBaseMapper<Tenant, TenantPostDto> _tenantPostDtoTenantMapper;
    private readonly IBaseMapper<Tenant, TenantPutDto> _tenantPutDtoTenantMapper;
    
    public TenantService(ITenantRepository tenantRepository, IBaseMapper<
        Tenant, TenantPostDto> tenantPostDtoTenantMapper, IBaseMapper<
        Tenant, TenantPutDto> tenantPutDtoTenantMapper)
    {
        _tenantRepository = tenantRepository;
        _tenantPostDtoTenantMapper = tenantPostDtoTenantMapper;
        _tenantPutDtoTenantMapper = tenantPutDtoTenantMapper;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateTenant(TenantPostDto tenant)
    {
        var tenantDto = _tenantPostDtoTenantMapper.ToEntity(tenant);
        return await _tenantRepository.AddAsync<Tenant>(tenantDto);
    }

    /// <inheritdoc/>
    public async Task<Tenant?> GetTenantById(Guid tenantId)
    {
        return await _tenantRepository.GetByIdAsync<Tenant>(tenantId);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Tenant>> GetAllTenants()
    {
        return await _tenantRepository.GetAllAsync<Tenant>();
    }

    /// <inheritdoc/>
    public async Task<Tenant> UpdateTenant(TenantPutDto tenant)
    {
        var tenantDto = _tenantPutDtoTenantMapper.ToEntity(tenant);
        return await _tenantRepository.UpdateAsync<Tenant>(tenantDto);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteTenant(Guid tenantId)
    {
        return await _tenantRepository.DeleteAsync<Tenant>(tenantId);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Tenant>> SearchAsync(SearchParameterRequest searchRequest)
    {
        return await _tenantRepository.SearchAsync<Tenant>(searchRequest);
    }

    /// <inheritdoc/>
    public async Task<PaginatedResponse<IEnumerable<Tenant>>> GetPaginatedTenantsAsync(int page, int pageSize)
    {
        return await _tenantRepository.GetPaginatedAsync<Tenant>(page, pageSize);
    }
}