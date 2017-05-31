namespace MyBaseProjectTemplate.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMyBaseProjectTemplateEfDBContext
    {
        DbSet<TEntity> Set<TEntity>()
           where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
