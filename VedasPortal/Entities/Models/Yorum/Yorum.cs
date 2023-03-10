using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.Yorum
{
    public class Yorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public bool OnaylansinMi { get; set; } = false;
        public int? ImageFileId { get; set; }
        public Dosya.ImageFile ImageFile { get; set; }
        public int? OneriId { get; set; }
        public Oneri.Oneri Oneri { get; set; }

        public int? DosyaId { get; set; }
        public Dosya.Dosya Dosya { get; set; }

        public int? EgitimId { get; set; }
        public Egitim.Egitim Egitim { get; set; }
        [DataType(DataType.Text)]
        public YorumDurum YorumDurum { get; set; } = YorumDurum.OnayBekleniyor;
    }

    public enum YorumDurum
    {
        OnayBekleniyor,
        Onaylandi,
        RedEdildi
    }
}