using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAndCore.Data.Models.Common;

namespace AngularAndCore.Data.Common
{
  public interface IMongoDbRepository<T>
    where T : BaseModel
  {
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(string id);

    Task Create(T entity);

    Task<bool> Update(string id, T entity);

    Task<bool> Delete(string id);
  }
}
