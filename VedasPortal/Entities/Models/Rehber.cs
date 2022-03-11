using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models
{
    public class Rehber : BaseEntity
    {
        public Dosya.Dosya ProfilResmi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Unvani { get; set; }
        public long TelefonNo { get; set; }
        public string Email { get; set; }
    }
}