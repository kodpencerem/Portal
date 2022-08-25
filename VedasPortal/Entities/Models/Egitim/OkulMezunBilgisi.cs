using System;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.Egitim
{
    public class OkulMezunBilgisi : Base.BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Okul Adı:")]
        [DataType(DataType.Text)]
        public string OkulAdi { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Başlama Tarihi:")]
        [DataType(DataType.Date)]
        public DateTime BaslamaTarihi { get; set; } = new DateTime(1900, 1, 1);

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Mezuniyet Tarihi:")]
        [DataType(DataType.Date)]
        public DateTime MezuniyetTarihi { get; set; } = new DateTime(1900, 1, 1);

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Eğitim Durumu:")]
        [DataType(DataType.Text)]
        public EgitimDurumu EgitimDurumu { get; set; }
    }
    public enum EgitimDurumu
    {
        IlkOkul,
        OrtaOkul,
        Lise,
        OnLisans,
        Lisans,
        YuksekLisans,
        Doktora,
        Master
    }
}
