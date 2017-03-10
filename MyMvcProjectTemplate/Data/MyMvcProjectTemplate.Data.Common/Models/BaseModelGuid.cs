namespace MyMvcProjectTemplate.Data.Common.Models
{
    using System;

    public class BaseModelGuid : BaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public BaseModelGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
