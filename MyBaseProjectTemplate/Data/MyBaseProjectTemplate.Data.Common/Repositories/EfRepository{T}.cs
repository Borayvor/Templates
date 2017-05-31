namespace MyBaseProjectTemplate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Bytes2you.Validation;
    using Contracts;
    using Data.Contracts;
    using Enums;
    using MyBaseProjectTemplate.Common.Constants;

    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        public EfRepository(IMyBaseProjectTemplateEfDBContext context)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.DbContextRequiredExceptionMessage).IsNull().Throw();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IMyBaseProjectTemplateEfDBContext Context { get; set; }

        private IDbSet<T> DbSet { get; set; }

        public void Create(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression,
                                         Expression<Func<T, T1>> sortExpression,
                                         SortOrder? sortOrder = null)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, sortOrder, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression,
                                              Expression<Func<T, T1>> sortExpression,
                                              SortOrder? sortOrder,
                                              Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                if (sortOrder != null && sortOrder == SortOrder.Descending)
                {
                    result = result.OrderByDescending(sortExpression);
                }
                else
                {
                    result = result.OrderBy(sortExpression);
                }
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }
    }
}
