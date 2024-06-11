using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Mappers.Tenant;

public class TenantPutDtoTenantMapper: IBaseMapper<Models.Tenant, TenantPutDto>
{
    public TenantPutDto ToDto(Models.Tenant entity)
    {
        return new TenantPutDto()
        {
            Id = entity.Id,
            TenantName = entity.TenantName,
            Status = entity.Status,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
        };
    }

    public Models.Tenant ToEntity(TenantPutDto dto)
    {
        var entity = new Models.Tenant
        {
            TenantName = dto.TenantName,
            UpdatedAt = dto.UpdatedAt,
            UpdatedBy = dto.UpdatedBy,
            Id = dto.Id,
        };
        
        if(dto.Status.HasValue)
            entity.Status = dto.Status.Value;
        
        return entity;
    }
}