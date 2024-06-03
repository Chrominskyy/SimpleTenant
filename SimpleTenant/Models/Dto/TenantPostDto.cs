using System.ComponentModel.DataAnnotations;
using Chrominsky.Utils.Enums;

namespace SimpleTenant.Models.Dto;

public class TenantPostDto
{
    /// <summary>
    /// Name of the tenant.
    /// </summary>
    [Required]
    public required string TenantName { get; set; }
    
    [Required]
    public required DatabaseEntityStatus Status { get; set; }
    
    [Required]
    public required string CreatedBy { get; set; }
}