using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Mappers.Tenant;

public class TenantPostDtoTenantMapper : IBaseMapper<Models.Tenant, TenantPostDto>
{
    public TenantPostDto ToDto(Models.Tenant entity)
    {
        return new TenantPostDto()
        {
            Status = entity.Status,
            TenantName = entity.TenantName,
            CreatedBy = entity.CreatedBy,
        };
    }

    public Models.Tenant ToEntity(TenantPostDto dto)
    {
        var entity = new Models.Tenant
        {
            TenantName = dto.TenantName,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy,
            Status = dto.Status,
        };

        return entity;
    }
}