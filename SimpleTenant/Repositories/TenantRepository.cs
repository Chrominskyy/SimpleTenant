using Chrominsky.Utils.Repositories.Base;
using Chrominsky.Utils.Repositories.ObjectVersioning;
using SimpleTenant.Contexts;
using SimpleTenant.Models;

namespace SimpleTenant.Repositories;

public class TenantRepository : BaseDatabaseRepository<Tenant>, ITenantRepository
{
    public TenantRepository(TenantDbContext dbContext, IObjectVersioningRepository objectVersioningRepository) : base(dbContext, objectVersioningRepository)
    {
    }
}