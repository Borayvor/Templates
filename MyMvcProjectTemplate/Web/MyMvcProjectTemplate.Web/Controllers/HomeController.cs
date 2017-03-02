namespace MyMvcProjectTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.ApplicationUser.Contracts;
    using ViewModels.User;

    public class HomeController : BaseController
    {
        private readonly IApplicationUserProfileService userProfileService;

        public HomeController(IApplicationUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        public ActionResult Index()
        {
            var viewModel = this.userProfileService.GetAll().To<UserHomePageViewModel>().ToList();

            return this.View(viewModel);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}