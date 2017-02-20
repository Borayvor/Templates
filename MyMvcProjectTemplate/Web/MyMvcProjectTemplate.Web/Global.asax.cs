namespace MyMvcProjectTemplate.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEnginesConfig.RegisterViewEngines();
            DatabaseConfig.RegisterDatabase();
            AutofacConfig.RegisterAutofac();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperAppConfig.RegisterAutoMapper();
        }
    }
}
