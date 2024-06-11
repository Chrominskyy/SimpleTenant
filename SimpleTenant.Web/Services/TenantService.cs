using Chrominsky.Utils.Enums;
using Chrominsky.Utils.Mappers.Base;
using Chrominsky.Utils.Models;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Web.Clients;

namespace SimpleTenant.Web.Services;

public class TenantService : ITenantService
{
    private readonly IApiClient _tenantApiClient;
    private readonly IBaseMapper<Tenant, TenantPostDto> _tenantPostDtoTenantMapper;
    private readonly IBaseMapper<Tenant, TenantPutDto> _tenantPutDtoTenantMapper;

    public TenantService
        (
            IApiClient tenantApiClient,
            IBaseMapper<Tenant, TenantPostDto> tenantPostDtoTenantMapper,
            IBaseMapper<Tenant, TenantPutDto> tenantPutDtoTenant
        )
    {
        _tenantApiClient = tenantApiClient;
        _tenantPostDtoTenantMapper = tenantPostDtoTenantMapper;
        _tenantPutDtoTenantMapper = tenantPutDtoTenant;
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
        return await _tenantApiClient.PostAsync<Tenant, TenantPostDto>("/api/tenants", tenant);
    }

    public async Task<Tenant> PutTenantAsync(TenantPutDto tenant)
    {
        return await _tenantApiClient.PutAsync<Tenant, TenantPutDto>("/api/tenants", tenant);
    }

    public async Task<bool> DeleteTenantAsync(Guid id)
    {
        return await _tenantApiClient.DeleteAsync($"/api/tenants/{id}");
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

    public async Task<bool> AddTenantAsync(Tenant tenant)
    {
        var tenantPostDto = _tenantPostDtoTenantMapper.ToDto(tenant);
        var response = await PostTenantAsync(tenantPostDto);
        return response.Id != Guid.Empty;
    }

    public async Task<bool> EditTenantAsync(Tenant tenant)
    {
        var dto = _tenantPutDtoTenantMapper.ToDto(tenant);
        var response = await PutTenantAsync(dto);
        return response.Id == tenant.Id;
    }

    public async Task<IEnumerable<Tenant>> SearchTenantAsync(SearchTenantRequestDto request)
    {

        var searchRequest = new SearchParameterRequest()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            SearchParameters = new List<SearchParameter>()
            {
                new()
                {
                    Key = "TenantName",
                    Value = request.TenantName,
                    Operator = request.SearchOperator
                }
            }
        };
        
        var response = await _tenantApiClient.PostAsync<IEnumerable<Tenant>, SearchParameterRequest>("/api/tenants/search", searchRequest);
        return response;
    }
}