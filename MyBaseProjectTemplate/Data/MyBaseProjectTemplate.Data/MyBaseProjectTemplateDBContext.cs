namespace MyBaseProjectTemplate.Data.Common
{
    using System.Data.Entity;
    using Contracts;

    public class MyBaseProjectTemplateDBContext : DbContext, IMyBaseProjectTemplateDBContext
    {
        public static MyBaseProjectTemplateDBContext Create()
        {
            return new MyBaseProjectTemplateDBContext();
        }
    }
}
