using Chrominsky.Utils.Models;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Web.Services;

/// <summary>
/// Interface for tenant related operations.
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Gets all tenants.
    /// </summary>
    /// <returns>An asynchronous task that returns an IEnumerable of Tenant.</returns>
    Task<IEnumerable<Tenant>> GetTenantsAsync();

    /// <summary>
    /// Gets a tenant by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the tenant.</param>
    /// <returns>An asynchronous task that returns a Tenant.</returns>
    Task<Tenant> GetTenantByIdAsync(Guid id);

    /// <summary>
    /// Creates a new tenant.
    /// </summary>
    /// <param name="tenant">The tenant data to be created.</param>
    /// <returns>An asynchronous task that returns a Tenant.</returns>
    Task<Tenant> PostTenantAsync(TenantPostDto tenant);

    /// <summary>
    /// Updates an existing tenant.
    /// </summary>
    /// <param name="tenant">The tenant data to be updated.</param>
    /// <returns>An asynchronous task that returns a Tenant.</returns>
    Task<Tenant> PutTenantAsync(TenantPutDto tenant);

    /// <summary>
    /// Deletes a tenant by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the tenant.</param>
    /// <returns>An asynchronous task that returns a boolean indicating success.</returns>
    Task<bool> DeleteTenantAsync(Guid id);

    /// <summary>
    /// Deactivates a tenant by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the tenant.</param>
    /// <returns>An asynchronous task that returns a boolean indicating success.</returns>
    Task<bool> DeactivateTenantAsync(Guid id);

    /// <summary>
    /// Activates a tenant by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the tenant.</param>
    /// <returns>An asynchronous task that returns a boolean indicating success.</returns>
    Task<bool> ActivateTenantAsync(Guid id);

    /// <summary>
    /// Adds a new tenant.
    /// </summary>
    /// <param name="tenant">The tenant data to be added.</param>
    /// <returns>An asynchronous task that returns a boolean indicating success.</returns>
    Task<bool> AddTenantAsync(Tenant tenant);

    /// <summary>
    /// Edits an existing tenant.
    /// </summary>
    /// <param name="tenant">The tenant data to be edited.</param>
    /// <returns>An asynchronous task that returns a boolean indicating success.</returns>
    Task<bool> EditTenantAsync(Tenant tenant);

    /// <summary>
    /// Searches for tenants based on the provided search criteria.
    /// </summary>
    /// <param name="request">The search criteria.</param>
    /// <returns>An asynchronous task that returns an IEnumerable of Tenant.</returns>
    Task<IEnumerable<Tenant>> SearchTenantAsync(SearchTenantRequestDto request);

    /// <summary>
    /// Gets a paginated list of tenants.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>An asynchronous task that returns a PaginatedResponse of IEnumerable of Tenant.</returns>
    Task<PaginatedResponse<IEnumerable<Tenant>>> GetPaginatedTenantsAsync(int page, int pageSize);
}