using Chrominsky.Utils.Enums;
using SimpleTenant.Models;

namespace SimpleTenant.Web.Models;

public class IndexViewModel
{
    public IEnumerable<Tenant> Tenants { get; set; }
    
    public string SearchTerm { get; set; }
    
    public SearchOperator? SearchOperator { get; set; }
}