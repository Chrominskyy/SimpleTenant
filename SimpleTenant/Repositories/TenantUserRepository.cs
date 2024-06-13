using Chrominsky.Utils.Repositories.Base;
using Chrominsky.Utils.Repositories.ObjectVersioning;
using Microsoft.EntityFrameworkCore;
using SimpleTenant.Models;

namespace SimpleTenant.Repositories;

public class TenantUserRepository : BaseDatabaseRepository<TenantUser>, ITenantUserRepository
{
    public TenantUserRepository(DbContext dbContext, IObjectVersioningRepository objectVersioningRepository) : base(dbContext, objectVersioningRepository)
    {
    }
}