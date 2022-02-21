using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VedasPortal.Utils.Anket.CustomValidation
{
    public class RequiredNumberOfSelectItemsAttribute : ValidationAttribute
    {
        public int RequiredNumberOfRecords { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            var numberOfItemsInList = ((List<SelectListItem>)value).Count();

            if (numberOfItemsInList < RequiredNumberOfRecords)
            {
                ErrorMessage = string.IsNullOrEmpty(ErrorMessage) ? $"{validationContext.MemberName} must have a minimum of {RequiredNumberOfRecords} items" : ErrorMessage;

                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });

            }

            return ValidationResult.Success;
        }
    }
}
