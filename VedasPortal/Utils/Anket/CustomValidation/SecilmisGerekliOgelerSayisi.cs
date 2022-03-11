using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VedasPortal.Utils.Anket.CustomValidation
{
    public class SecilmisGerekliOgelerSayisi : ValidationAttribute
    {
        public int GerekliKayitSayisi { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var numberOfItemsInList = ((List<SelectListItem>)value).Count();
            if (numberOfItemsInList < GerekliKayitSayisi)
            {
                ErrorMessage = string.IsNullOrEmpty(ErrorMessage) ? $"{validationContext.MemberName} en az {GerekliKayitSayisi} öğeye sahip olmalıdır" : ErrorMessage;
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}