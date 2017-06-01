using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyBaseProjectTemplate.Data.Contracts
{
    public interface IMyBaseProjectTemplateEfDBContext
    {
        DbSet<TEntity> Set<TEntity>()
           where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
