using System;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.DuzelticiFaaliyet
{
    public class DuzelticiFaaliyet : BaseEntity
    {
        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(50, ErrorMessage = "50'den fazla karakter giremezsiniz!"), Display(Name = "Faaliyet Adı:")]
        public string FaaliyetGurupAdi { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            StringLength(500, ErrorMessage = "500'den fazla karakter giremezsiniz!"),
            Display(Name = "İstediğiniz Faaliyet Konusu:")]
        public string IstekFaaliyetKonusu { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"),
            StringLength(500, ErrorMessage = "500'den fazla karakter giremezsiniz!"),
            Display(Name = "Açıklama:")]
        public string Aciklama { get; set; }
        public DateTime BildirimTarihi { get; set; } = DateTime.Now.Date;

        public bool AktifPasif { get; set; } = true;

        public virtual Dosya.Dosya Resim { get; set; }

        [DataType(DataType.Text)]
        public DuzelticiFaaliyetKategori Kategori { get; set; }

        public string KonuEtiketi { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(500, ErrorMessage = "500'den fazla karakter giremezsiniz!"), Display(Name = "Lokasyon Bilgisi:")]
        public string LokasyonBilgisi { get; set; }

        //public int KisiId { get; set; }
        //[ForeignKey("KisiId")]
        //public virtual PersonelBilgi PersonelBilgi { get; set; }
    }

    public enum DuzelticiFaaliyetKategori
    {
        CevreAydinlatma,
        KopruKavsakAydinlatma,
        ProsedurVePolitikalar,
    }
}
