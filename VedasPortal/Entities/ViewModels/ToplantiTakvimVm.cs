using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.ViewModels
{
    public class ToplantiTakvimVm
    {
        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string MerkezId { get; set; }
        public List<SelectListItem> TMerkezler { get; set; }

        [Required(ErrorMessage = "Bu Alan Gereklidir!")]
        public string ToplantiOdasiId { get; set; }
        public List<SelectListItem> OdaListe { get; set; }
    }
}