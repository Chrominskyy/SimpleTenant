using Microsoft.EntityFrameworkCore;
using SimpleTenant.Contexts;

namespace SimpleTenant.Repositories;

public class ObjectVersioningRepository : Chrominsky.Utils.Repositories.ObjectVersioning.ObjectVersioningRepository
{
    public ObjectVersioningRepository(TenantDbContext dbContext) : base(dbContext)
    {
    }
}