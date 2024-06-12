using Chrominsky.Utils.Models;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Services;
/// <summary>
/// Interface for tenant related operations.
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Creates a new tenant.
    /// </summary>
    /// <param name="tenant">The tenant object to be created.</param>
    /// <returns>The newly created tenant object.</returns>
    Task<Guid> CreateTenant(TenantPostDto tenant);

    /// <summary>
    /// Retrieves a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant.</param>
    /// <returns>The tenant object with the specified identifier.</returns>
    Task<Tenant?> GetTenantById(Guid tenantId);
    
    /// <summary>
    /// Retrieves all tenants.
    /// </summary>
    /// <returns>An enumerable collection of tenant objects.</returns>
    Task<IEnumerable<Tenant>> GetAllTenants();

    /// <summary>
    /// Updates an existing tenant.
    /// </summary>
    /// <param name="tenant">The tenant object to be updated.</param>
    /// <returns>The updated tenant object.</returns>
    Task<Tenant> UpdateTenant(TenantPutDto tenant);

    /// <summary>
    /// Deletes a tenant by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant.</param>
    Task<bool> DeleteTenant(Guid tenantId);
    
    /// <summary>
    /// Performs a search operation on tenants based on the provided search parameters.
    /// </summary>
    /// <param name="searchRequest">The search parameters to be used for filtering the tenants.</param>
    /// <returns>An enumerable collection of tenant objects that match the search criteria.</returns>
    Task<IEnumerable<Tenant>> SearchAsync(SearchParameterRequest searchRequest);

    /// <summary>
    /// Retrieves a paginated list of tenants.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A PaginatedResponse object containing the requested page of tenant objects.</returns>
    Task<PaginatedResponse<IEnumerable<Tenant>>> GetPaginatedTenantsAsync(int page, int pageSize);
}