namespace MyBaseProjectTemplate.Data.Common.DbContextSave
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Bytes2you.Validation;
    using Contracts;
    using MyBaseProjectTemplate.Common.Constants;

    public class EfDbContextSaveChanges : IContextSaveChanges
    {
        public EfDbContextSaveChanges(DbContext context)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.DbContextRequiredExceptionMessage).IsNull().Throw();

            this.Context = context;
        }

        private DbContext Context { get; set; }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }
    }
}
