namespace MyMvcProjectTemplate.Services.ApplicationUser
{
    using System.Linq;
    using Common.Contracts;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class ApplicationUserProfileService : IApplicationUserProfileService,
        IBaseGetService<ApplicationUser, string>
    {
        private readonly IEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IEfDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All().OrderByDescending(x => x.CreatedOn);
        }

        public ApplicationUser GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
