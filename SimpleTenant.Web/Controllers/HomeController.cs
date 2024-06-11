using System.Diagnostics;
using System.Text.Json;
using Chrominsky.Utils.Enums;
using Microsoft.AspNetCore.Mvc;
using SimpleTenant.Models;
using SimpleTenant.Models.Dto;
using SimpleTenant.Web.Services;
using SimpleTenant.Web.Models;

namespace SimpleTenant.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITenantService _tenantService;

    public HomeController(ILogger<HomeController> logger, ITenantService tenantService)
    {
        _logger = logger;
        _tenantService = tenantService;
    }

    public async Task<IActionResult> Index(IndexViewModel model)
    {
        if (TempData.TryGetValue("SearchTenants", out object? value))
        {
            model.Tenants = JsonSerializer.Deserialize<List<Tenant>>(value.ToString());
            TempData.Remove("SearchTenants");
        }

        if (TempData.TryGetValue("SearchTenantName", out value))
        {
            model.SearchTerm = value.ToString();
            TempData.Remove("SearchTenantName");
        }

        if (TempData.TryGetValue("SearchOperator", out value))
        {
            model.SearchOperator = (SearchOperator)Enum.Parse(typeof(SearchOperator), value.ToString());
            TempData.Remove("SearchOperator");
        }
        
        if (model.Tenants == null || (!model.Tenants.Any() && string.IsNullOrEmpty(model.SearchTerm)))
        {
            var tenants = await _tenantService.GetTenantsAsync();
            model = new IndexViewModel { Tenants = tenants };
        }

        model.SearchOperator ??= SearchOperator.Contains;
        
        
        return View(model);
    }

    public async Task<IActionResult> Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);
        var viewModel = new EditTenantViewModel
        {
            Id = tenant.Id,
            TenantName = tenant.TenantName,
            CreatedAt = tenant.CreatedAt,
            UpdatedAt = tenant.UpdatedAt??DateTime.MinValue,//for now, will be fixed later
            CreatedBy = tenant.CreatedBy,
            UpdatedBy = tenant.UpdatedBy,
            Status = tenant.Status
        };
        return View("Tenant", viewModel);
    }

    public async Task<IActionResult> Remove(Guid id)
    {
        await _tenantService.DeleteTenantAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Disable(Guid id)
    {
        await _tenantService.DeactivateTenantAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Enable(Guid id)
    {
        await _tenantService.ActivateTenantAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult AddNew()
    {
        var viewModel = new EditTenantViewModel()
        {
            Id = Guid.Empty
        };
        return View("Tenant", viewModel);
    }

    public async Task<IActionResult> AddEditTenant(Tenant tenant)
    {
        if (ModelState.IsValid)
        {
            if (tenant.Id == Guid.Empty)
                await _tenantService.AddTenantAsync(tenant);
            else
                await _tenantService.EditTenantAsync(tenant);
            return RedirectToAction(nameof(Index));
        }

        return View("Tenant");
    }
    
    public async Task<IActionResult> SearchTenant(IndexViewModel model)
    {
        model.Tenants = await _tenantService.SearchTenantAsync(new SearchTenantRequestDto()
        {
            Page = 1,
            PageSize = 10000,
            TenantName = model.SearchTerm,
            SearchOperator = model.SearchOperator??SearchOperator.Contains
        });

        TempData["SearchTenants"] = JsonSerializer.Serialize(model.Tenants);
        TempData["SearchTenantName"] = model.SearchTerm;
        TempData["SearchOperator"] = model.SearchOperator;
        return RedirectToAction(nameof(Index));
    }
}