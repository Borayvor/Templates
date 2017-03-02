namespace MyMvcProjectTemplate.Services.ApplicationUser.Contracts
{
    using Common.Contracts;
    using Data.Models;

    public interface IApplicationUserProfileService : IBaseGetService<ApplicationUser, string>
    {
    }
}
