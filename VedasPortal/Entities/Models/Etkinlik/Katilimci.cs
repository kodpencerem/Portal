using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Etkinlik
{
    public class Katilimci : BaseEntity
    {
        public string AdSoyad { get; set; }
        public string EMail { get; set; }
        public string TelefonNo { get; set; }
        public bool KatilisDurumu { get; set; }
        public string KatilisNedeni { get; set; }
        public virtual Dosya.Dosya Resim { get; set; }
        public Etkinlik Etkinlik { get; set; }
    }
}