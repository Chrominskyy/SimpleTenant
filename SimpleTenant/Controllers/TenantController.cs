using Chrominsky.Utils.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Services;

namespace SimpleTenant.Controllers
{

    /// <summary>
    /// Controller for managing tenants.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="tenantService">The tenant service.</param>
        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        /// <summary>
        /// Gets a paginated list of tenants.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A paginated list of tenants.</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<IEnumerable<Tenant>>>> Get([FromQuery] int page, [FromQuery] int pageSize)
        {
            return Ok(await _tenantService.GetPaginatedTenantsAsync(page, pageSize));
        }

        /// <summary>
        /// Gets a tenant by its ID.
        /// </summary>
        /// <param name="id">The tenant ID.</param>
        /// <returns>The tenant if found, otherwise NotFound.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Tenant>> Get(Guid id)
        {
            var tenant = await _tenantService.GetTenantById(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant);
        }

        /// <summary>
        /// Creates a new tenant.
        /// </summary>
        /// <param name="tenant">The tenant data.</param>
        /// <returns>The created tenant.</returns>
        [HttpPost]
        public async Task<ActionResult<Tenant>> Post(TenantPostDto tenant)
        {
            var tenantId = await _tenantService.CreateTenant(tenant);
            return CreatedAtAction(nameof(Get), new { id = tenantId }, tenant);
        }

        /// <summary>
        /// Updates an existing tenant.
        /// </summary>
        /// <param name="tenant">The tenant data.</param>
        /// <returns>The updated tenant.</returns>
        [HttpPut]
        public async Task<ActionResult<Tenant>> Put(TenantPutDto tenant)
        {
            var ret = await _tenantService.UpdateTenant(tenant);
            return Ok(ret);
        }

        /// <summary>
        /// Deletes a tenant by its ID.
        /// </summary>
        /// <param name="id">The tenant ID.</param>
        /// <returns>NoContent if successful, otherwise NotFound.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ret = await _tenantService.DeleteTenant(id);
            if (!ret)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Searches for tenants based on search parameters.
        /// </summary>
        /// <param name="searchRequest">The search parameters.</param>
        /// <returns>A list of matching tenants.</returns>
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Tenant>>> Search([FromBody] SearchParameterRequest searchRequest)
        {
            return Ok(await _tenantService.SearchAsync(searchRequest));
        }
    }
}