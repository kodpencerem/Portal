using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.HaberDuyuru

{
    public class HaberDuyuru : BaseEntity
    {   
        public int No { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Haber/Duyuru Başlığı:")]
        [DataType(DataType.Text)]
        public string Adi { get; set; }
        public string AltBaslik { get; set; }
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