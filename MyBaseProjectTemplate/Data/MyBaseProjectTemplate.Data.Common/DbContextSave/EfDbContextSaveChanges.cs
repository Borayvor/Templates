using System.Data.Entity;
using System.Threading.Tasks;
using Bytes2you.Validation;
using MyBaseProjectTemplate.Common.Constants;
using MyBaseProjectTemplate.Data.Contracts;

namespace MyBaseProjectTemplate.Data.Common.DbContextSave
{
    public class EfDbContextSaveChanges : IDbContextSaveChanges
    {
        public EfDbContextSaveChanges(DbContext context)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.DbContextRequiredExceptionMessage).IsNull().Throw();

            this.Context = context;
        }

        private DbContext Context { get; set; }

        public int Save()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return this.Context.SaveChangesAsync();
        }
    }
}
