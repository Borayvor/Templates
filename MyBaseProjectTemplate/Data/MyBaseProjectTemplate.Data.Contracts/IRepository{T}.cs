using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyBaseProjectTemplate.Common.Enums;

namespace MyBaseProjectTemplate.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        void Create(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression,
                                  Expression<Func<T, T1>> sortExpression,
                                  SortOrder? sortOrder);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression,
                                       Expression<Func<T, T1>> sortExpression,
                                       SortOrder? sortOrder,
                                       Expression<Func<T, T2>> selectExpression);

        T GetById(object id);

        void Update(T entity);

        void Delete(T entity);
    }
}
