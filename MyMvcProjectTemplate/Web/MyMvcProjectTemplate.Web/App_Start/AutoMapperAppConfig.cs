namespace MyMvcProjectTemplate.Web.App_Start
{
    using System.Reflection;
    using MyMvcProjectTemplate.Web.Infrastructure.Mapping;

    public class AutoMapperAppConfig
    {
        public static void RegisterAutoMapper()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
