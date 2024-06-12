using System.Globalization;
using Chrominsky.Utils.Enums;
using SimpleTenant.Models;

namespace SimpleTenant.Web.Models;

public class IndexViewModel
{
    public IEnumerable<Tenant> Tenants { get; set; }
    
    public string SearchTerm { get; set; }
    
    public SearchOperator? SearchOperator { get; set; }
    
    public int Page { get; set; } = 1;
    
    public int PageSize { get; set; } = 10;

    public int TotalPages => int.Parse(Math.Ceiling((double)TotalCount / PageSize)
        .ToString(CultureInfo.InvariantCulture));
    
    public int TotalCount { get; set; }
}