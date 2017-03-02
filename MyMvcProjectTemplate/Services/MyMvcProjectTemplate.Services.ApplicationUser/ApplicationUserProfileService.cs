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
        protected readonly IDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public ApplicationUser GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
