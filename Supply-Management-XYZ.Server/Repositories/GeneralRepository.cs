using Supply_Management_XYZ.Server.Contracts;
using Supply_Management_XYZ.Server.Data;

namespace Supply_Management_XYZ.Server.Repositories;

public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
{
    protected readonly SupplyManagementDbContext Context;

    public GeneralRepository(SupplyManagementDbContext context)
    {
        Context = context;
    }

    public ICollection<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public TEntity? GetByGuid(Guid guid)
    {
        var entity = Context.Set<TEntity>().Find(guid);
        Context.ChangeTracker.Clear();
        return entity;
    }

    public TEntity? Create(TEntity entity)
    {
        try
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public bool Update(TEntity entity)
    {
        try
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(TEntity entity)
    {
        try
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
