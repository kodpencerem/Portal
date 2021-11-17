using System;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;

namespace VedasPortal.Models
{
    public class Duyuru : BaseEntity
    {
        public string Resim { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(50, ErrorMessage = "50'den fazla karakter giremezsiniz!"), Display(Name = "Duyuru Adı:")]
        public string DuyuruAdi { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(1000, ErrorMessage = "1000'den fazla karakter giremezsiniz!"), Display(Name = "Açıklama:")]
        public string DuyuruAciklama { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        //[Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(50, ErrorMessage = "50'den fazla karakter giremezsiniz!"), Display(Name = "Unvan Bilgisi:")]
        //public string EkleyenYetkiliUnvani { get; set; }

        //[Required(ErrorMessage = "Bu alan gereklidir. Boş geçemezsiniz!"), StringLength(50, ErrorMessage = "50'den fazla karakter giremezsiniz!"), Display(Name = "Ad Soyad:")]
        //public string EkleyenYetkiliAdSoyad { get; set; }


    }
}
