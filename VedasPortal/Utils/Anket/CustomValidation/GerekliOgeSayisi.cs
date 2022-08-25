using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Entities.DTOs.Anket;

namespace VedasPortal.Utils.Anket.CustomValidation
{
    public class GerekliOgeSayisi : ValidationAttribute
    {
        public int GerekliKayitSayisi { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var numberOfItemsInList = ((List<AnketSecenekDTO>)value).Count();
            if (numberOfItemsInList < GerekliKayitSayisi)
            {
                ErrorMessage = string.IsNullOrEmpty(ErrorMessage) ?
                    $"{validationContext.MemberName} en az {GerekliKayitSayisi} öğeye sahip olmalıdır" :
                    ErrorMessage;
                return new ValidationResult(ErrorMessage,
                    new[] { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}