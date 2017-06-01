using System.Data.Entity;
using System.Threading.Tasks;
using MyBaseProjectTemplate.Common.Constants;
using MyBaseProjectTemplate.Data.Contracts;

namespace MyBaseProjectTemplate.Data.Common
{
    public class MyBaseProjectTemplateEfDBContext : DbContext,
        IMyBaseProjectTemplateEfDBContext, IDbContextSaveChanges
    {
        public MyBaseProjectTemplateEfDBContext()
            : base(GlobalConstants.ConnectionStringName)
        {
        }

        public static MyBaseProjectTemplateEfDBContext Create()
        {
            return new MyBaseProjectTemplateEfDBContext();
        }

        public int Save()
        {
            return this.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return this.SaveChangesAsync();
        }
    }
}
