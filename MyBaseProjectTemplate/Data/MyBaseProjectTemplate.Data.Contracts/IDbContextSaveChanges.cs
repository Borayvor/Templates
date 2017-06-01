using System.Threading.Tasks;

namespace MyBaseProjectTemplate.Data.Contracts
{
    public interface IDbContextSaveChanges
    {
        int Save();

        Task<int> SaveAsync();
    }
}
