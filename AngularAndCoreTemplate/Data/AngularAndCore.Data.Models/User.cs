using AngularAndCore.Data.Models.Common;

namespace AngularAndCore.Data.Models
{
  public class User : BaseModel, IBaseModel, IAuditInfo, IDeletableEntity
  {
    public string Username { get; set; }

    public string Password { get; set; }
  }
}
