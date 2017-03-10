namespace MyMvcProjectTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using MyMvcProjectTemplate.Common.Constants;

    public class Photocourse : BaseModelGuid, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }
    }
}
