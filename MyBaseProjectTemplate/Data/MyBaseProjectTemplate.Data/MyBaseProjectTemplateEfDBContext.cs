namespace MyBaseProjectTemplate.Data.Common
{
    using System.Data.Entity;
    using Contracts;

    public class MyBaseProjectTemplateEfDBContext : DbContext, IMyBaseProjectTemplateEfDBContext
    {
        public static MyBaseProjectTemplateEfDBContext Create()
        {
            return new MyBaseProjectTemplateEfDBContext();
        }
    }
}
