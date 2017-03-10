namespace MyMvcProjectTemplate.Services.Photocourse
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IEfDbRepository<Photocourse> photocourses;

        public PhotocourseService(IEfDbRepository<Photocourse> photocourses)
        {
            this.photocourses = photocourses;
        }

        public void Create(Photocourse entity)
        {
            this.photocourses.Create(entity);
        }

        public IQueryable<Photocourse> GetAll()
        {
            return this.photocourses.All().OrderByDescending(x => x.CreatedOn);
        }

        public Photocourse GetById(Guid id)
        {
            return this.photocourses.GetById(id);
        }

        public void Update(Photocourse entity)
        {
            this.photocourses.Update(entity);
        }

        public void Delete(Photocourse entity)
        {
            this.photocourses.Delete(entity);
        }
    }
}
