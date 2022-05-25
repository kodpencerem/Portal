using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.ViewModels
{
    public class ToplantiTakvimVm
    {
        [Required(ErrorMessage = "Toplantı Merkezi Adi Gerekli")]
        public string MerkezId { get; set; }
        public List<SelectListItem> ListofToplantiMerkezleri { get; set; }

        [Required(ErrorMessage = "Toplanti Odası Adı Gerekli")]
        public string OdaId { get; set; }
        public List<SelectListItem> ListofToplantiOdalari { get; set; }
    }
}