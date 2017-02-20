namespace MyMvcProjectTemplate.Services.Common.Contracts
{
    using Data.Common.Models;

    public interface IBaseUpdateService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(T entity);
    }
}
