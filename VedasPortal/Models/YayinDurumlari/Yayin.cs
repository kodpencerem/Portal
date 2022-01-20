using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.YayinDurumlari
{
    public class Yayin : BaseEntity
    {
        public int No { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            StringLength(250, ErrorMessage = "250'den fazla karakter giremezsiniz!"),
            Display(Name = "Duyuru Adı:")]
        public string Adi { get; set; }

        public string AltBaslik { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            Display(Name = "Açıklama:")]
        public string Aciklama { get; set; }

        public bool YayinDurumu { get; set; }

        public byte[] DosyaBoyutu { get; set; }

        public string DosyaYolu { get; set; }

        public bool DuyuruKutusundaOlsunMu { get; set; }

        public bool SlideraEklensinMi { get; set; }

        public int YayinKategoriId { get; set; }
        [ForeignKey("YayinKategoriId")]
        public YayinKategori YayinKategori { get; set; }
    }
}
