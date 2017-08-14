using MongoDB.Driver;

namespace AngularAndCore.Data
{
  public interface IMongoDbContext
  {
    IMongoCollection<T> Set<T>()
      where T : class;
  }
}