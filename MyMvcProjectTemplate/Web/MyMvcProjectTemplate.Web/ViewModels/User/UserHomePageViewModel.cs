namespace MyMvcProjectTemplate.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserHomePageViewModel : BaseViewModel<string>, IMapFrom<ApplicationUser>
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
