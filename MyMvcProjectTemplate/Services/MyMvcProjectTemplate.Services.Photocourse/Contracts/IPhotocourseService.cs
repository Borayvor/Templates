namespace MyMvcProjectTemplate.Services.Photocourse.Contracts
{
    using System;
    using Common.Contracts;
    using Data.Models;

    public interface IPhotocourseService : IBaseCreateService<Photocourse>,
        IBaseGetService<Photocourse, Guid>,
        IBaseUpdateService<Photocourse>,
        IBaseDeleteService<Photocourse>
    {
    }
}
