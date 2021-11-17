using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Models
{
    public class HavaTahminAramaModeli
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Sadece latin harfleri ile arama yapın!")]
        public string SehirAdi { get; set; }
    }
}
