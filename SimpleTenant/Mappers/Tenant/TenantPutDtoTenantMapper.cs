using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Mappers.Tenant;

/// <summary>
/// This class is responsible for mapping between <see cref="Models.Tenant"/> and <see cref="TenantPutDto"/>.
/// It implements the <see cref="IBaseMapper{Models.Tenant, TenantPutDto}"/> interface.
/// </summary>
public class TenantPutDtoTenantMapper: IBaseMapper<Models.Tenant, TenantPutDto>
{
    /// <summary>
    /// Maps a <see cref="Models.Tenant"/> entity to a <see cref="TenantPutDto"/> object.
    /// </summary>
    /// <param name="entity">The <see cref="Models.Tenant"/> entity to map.</param>
    /// <returns>A <see cref="TenantPutDto"/> object containing the mapped data.</returns>
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

    /// <summary>
    /// Maps a <see cref="TenantPutDto"/> object to a <see cref="Models.Tenant"/> entity.
    /// </summary>
    /// <param name="dto">The <see cref="TenantPutDto"/> object to map.</param>
    /// <returns>A <see cref="Models.Tenant"/> entity containing the mapped data.</returns>
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