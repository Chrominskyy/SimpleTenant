using SimpleTenant.Models;

namespace SimpleTenant.Web.Models;

public class IndexViewModel
{
    public IEnumerable<Tenant> Tenants { get; set; }
}