namespace MyBaseProjectTemplate.Data.Common.Contracts
{
    using System.Threading.Tasks;

    public interface IContextSaveChanges
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
