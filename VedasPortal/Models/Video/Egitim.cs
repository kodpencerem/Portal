using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;
using VedasPortal.Models.Etkinlik;

namespace VedasPortal.Models.Video
{
    public class Egitim : BaseEntity
    {
        public Dosya.Dosya Kapak { get; set; }

        public Video Video { get; set; }

        public string Adi { get; set; }

        public string Aciklama { get; set; }

        public string Gereksinim { get; set; }

        public string Egitmen { get; set; }

        public bool AktifPasif { get; set; }

        public bool IzlenmeDurumu { get; set; }

        public decimal ToplamIzlenme { get; set; }

        public bool TamamlandiMi { get; set; }

        public string Sertifika { get; set; }

        public string KonuBasligi { get; set; }

        public decimal ToplamUzunluk { get; set; }

        public string KimlereUygun { get; set; }
        
        [DataType(DataType.Text)]
        public EgitimKategori Kategori { get; set; }

        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
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
        KurumsalIletisim
    }
}
