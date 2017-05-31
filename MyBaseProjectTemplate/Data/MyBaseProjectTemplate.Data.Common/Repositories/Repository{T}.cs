namespace MyBaseProjectTemplate.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        public Repository(MyBaseProjectTemplateDBContext context)
        {
            this.Context = context;
        }

        private MyBaseProjectTemplateDBContext Context { get; set; }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
