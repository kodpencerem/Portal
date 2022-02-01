using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;
using VedasPortal.Models.Dosya;

namespace VedasPortal.Models.HaberDuyuru

{
    public class HaberDuyuru : BaseEntity
    {

        public HaberDuyuru()
        {
            Dosya = new HashSet<Dosya.Dosya>();
        }
        public int No { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            StringLength(250, ErrorMessage = "250'den fazla karakter giremezsiniz!"),
            Display(Name = "Duyuru Adı:")]
        public string Adi { get; set; }
        public string AltBaslik { get; set; }
        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            Display(Name = "Açıklama:")]
        public string Aciklama { get; set; }
        public bool SliderdaGoster { get; set; } = false;
        [DataType(DataType.Text)]
        public HaberDuyuruKategori Kategori { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool AnasayfadaGoster { get; set; } = true;
        public virtual ICollection<Dosya.Dosya> Dosya { get; set; }
    }

    public enum HaberDuyuruKategori
    {
        Duyuru,
        Haber,
    }

}
