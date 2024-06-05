using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Chrominsky.Utils.Enums;
using Newtonsoft.Json;

namespace SimpleTenant.Models.Dto;

public class TenantPutDto
{
    [Required]
    public Guid Id { get; set; }
    
    public string? TenantName { get; set; }
    
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public string? UpdatedBy { get; set; }
    
    [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
    public DatabaseEntityStatus? Status { get; set; }
}