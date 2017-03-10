using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyMvcProjectTemplate.Web.Startup))]
namespace MyMvcProjectTemplate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
