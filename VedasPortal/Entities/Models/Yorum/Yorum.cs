using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Entities.Models.Yorum
{
    public class Yorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public bool OnaylansinMi { get; set; } = false;
        public int? DosyaId { get; set; }
        public Dosya.Dosya Dosya { get; set; }
        public int? OneriId { get; set; }
        public Oneri.Oneri Oneri { get; set; }

        public int? VidyoId { get; set; }
        public Vidyo Vidyo { get; set; }
    }
}