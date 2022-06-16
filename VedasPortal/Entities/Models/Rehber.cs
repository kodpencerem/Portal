using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Entities.Models
{
    public class Rehber : BaseEntity
    {
        
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Unvani { get; set; }
        public long TelefonNo { get; set; }
        public string Email { get; set; }
        public string Lokasyon { get; set; }
        public bool AktifPasif { get; set; } = true;
        public ICollection<Dosya.ImageFile> Dosya { get; set; }
    }
}