using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;
using VedasPortal.Models.Dokuman;

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

        public string DosyaYolu { get; set; }

        public bool YayinDurumu { get; set; }

        //public int DosyaId { get; set; }
        //[ForeignKey("DosyaId")]
        //public DosyaYukle DosyaYukle { get; set; }

    }

    //public enum YayinDurumlari
    //{
    //    Duyuru,
    //    Haber,

    //}
}
