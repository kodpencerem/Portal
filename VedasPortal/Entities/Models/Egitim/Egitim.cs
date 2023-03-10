using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.PersonelDurumlari;

namespace VedasPortal.Entities.Models.Egitim
{
    public class Egitim : BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Adi { get; set; }
        public string AltBaslik { get; set; }
        public string Aciklama { get; set; }
        public string Gereksinim { get; set; }
        public string Egitmen { get; set; }
        public bool AktifPasif { get; set; }
        public bool IzlenmeDurumu { get; set; }
        public long ToplamIzlenme { get; set; }
        public bool TamamlandiMi { get; set; }
        public string Sertifika { get; set; }
        public string KonuBasligi { get; set; }
        public long ToplamUzunluk { get; set; }
        public string KimlereUygun { get; set; }
        [DataType(DataType.Text)]
        public EgitimKategori Kategori { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public ICollection<Dosya.Dosya> Dosya { get; set; }
        public ICollection<Yorum.Yorum> Yorum { get; set; }

        public int? PersonelDurumId { get; set; }
        public PersonelDurum PersonelDurum { get; set; }
    }

    public enum EgitimKategori
    {
        Yazilim,
        Elektrik,
        ElektrikElektronik,
        Muhasebe,
        Isletme,
        KisiselGelisim,
        OfisUygulamalari,
        Tasarim,
        Pazarlama,
        YasamTarzi,
        SaglikVeFitnes,
        FotografVeVideo
    }

    public enum Birimler
    {
        TumBirimler,
        Scada,
        BilgiIslem,
        CagriMerkezi,
        Hukuk,
        KaliteMudurlugu,
        InsanKaynaklari,
        Sayac,
        KacakVeTahakkuk,
        Icra,
        KurumsalIletisim,
    }
}