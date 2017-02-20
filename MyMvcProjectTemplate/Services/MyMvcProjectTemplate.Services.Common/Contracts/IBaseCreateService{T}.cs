namespace MyMvcProjectTemplate.Services.Common.Contracts
{
    using Data.Common.Models;

    public interface IBaseCreateService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Create new <"T">.
        /// </summary>
        /// <param name="content"><"T"> to be created.</param>
        void Create(T entity);
    }
}
