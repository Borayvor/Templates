namespace MyMvcProjectTemplate.Services.Common.Contracts
{
    using Data.Common.Models;

    /// <summary>
    /// Common Update service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseUpdateService<T>
        where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(T entity);
    }
}
