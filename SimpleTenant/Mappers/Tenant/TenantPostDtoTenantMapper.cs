using Chrominsky.Utils.Mappers.Base;
using SimpleTenant.Models.Dto;

namespace SimpleTenant.Mappers.Tenant;

/// <summary>
/// This class is responsible for mapping between <see cref="Models.Tenant"/> and <see cref="TenantPostDto"/>.
/// It implements the <see cref="IBaseMapper{Models.Tenant, TenantPostDto}"/> interface.
/// </summary>
public class TenantPostDtoTenantMapper : IBaseMapper<Models.Tenant, TenantPostDto>
{
    /// <summary>
    /// Maps a <see cref="Models.Tenant"/> entity to a <see cref="TenantPostDto"/> object.
    /// </summary>
    /// <param name="entity">The <see cref="Models.Tenant"/> entity to map.</param>
    /// <returns>A <see cref="TenantPostDto"/> object containing the mapped data.</returns>
    public TenantPostDto ToDto(Models.Tenant entity)
    {
        return new TenantPostDto()
        {
            Status = entity.Status,
            TenantName = entity.TenantName,
            CreatedBy = entity.CreatedBy,
        };
    }

    /// <summary>
    /// Maps a <see cref="TenantPostDto"/> object to a <see cref="Models.Tenant"/> entity.
    /// </summary>
    /// <param name="dto">The <see cref="TenantPostDto"/> object to map.</param>
    /// <returns>A <see cref="Models.Tenant"/> entity containing the mapped data.</returns>
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