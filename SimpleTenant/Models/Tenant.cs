using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Chrominsky.Utils.Models.Base;

namespace SimpleTenant.Models;

/// <summary>
/// Represents a tenant in the application.
/// </summary>
[Table("Tenants")]
public class Tenant : BaseDatabaseEntity
{
    /// <summary>
    /// Name of the tenant.
    /// </summary>
    [Required]
    public required string? TenantName { get; set; }
}