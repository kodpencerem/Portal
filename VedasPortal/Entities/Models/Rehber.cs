using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models
{
    public class Rehber : BaseEntity
    {

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Unvani { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public long TelefonNo { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [EmailAddress]
        public string Email { get; set; }
        public string Lokasyon { get; set; }
        public bool AktifPasif { get; set; } = true;
        public ICollection<Dosya.ImageFile> ImageFile { get; set; }
    }
}