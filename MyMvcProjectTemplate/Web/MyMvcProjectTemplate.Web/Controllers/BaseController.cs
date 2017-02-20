namespace MyMvcProjectTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        protected ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}