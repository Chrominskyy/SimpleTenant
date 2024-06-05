using Chrominsky.Utils.Enums;
using SimpleTenant.Models;

namespace SimpleTenant.Web.Models;

public class EditTenantViewModel
{
    public Guid Id { get; set; }
    
    public string? TenantName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public DatabaseEntityStatus Status { get; set; }
}