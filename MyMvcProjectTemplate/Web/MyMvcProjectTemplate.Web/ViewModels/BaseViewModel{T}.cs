namespace MyMvcProjectTemplate.Web.ViewModels
{
    using System;
    using System.Web.Mvc;

    public abstract class BaseViewModel<T>
    {
        [HiddenInput(DisplayValue = false)]
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
