namespace MyMvcProjectTemplate.Services.Common.Contracts
{
    using Data.Common.Models;

    public interface IBaseDeleteService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Delete <"T">. Not permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted.</param>
        void Delete(T entity);
    }
}
