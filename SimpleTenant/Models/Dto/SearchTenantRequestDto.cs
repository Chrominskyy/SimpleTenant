using Chrominsky.Utils.Enums;

namespace SimpleTenant.Models.Dto;

public class SearchTenantRequestDto
{
    public string TenantName { get; set; }
    
    public int Page { get; set; }
    
    public int PageSize { get; set; }
    
    public SearchOperator SearchOperator { get; set; }
}