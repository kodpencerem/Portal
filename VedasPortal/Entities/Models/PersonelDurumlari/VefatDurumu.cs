using System;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.PersonelDurumlari
{
    public class VefatDurumu : Base.BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string AdSoyad { get; set; }
        public string TelefonNo { get; set; }
        public string CalistigiYer { get; set; }
        public string YakinlikDerecesi { get; set; }
        public string YakininAdSoyadi { get; set; }
        public DateTime? VefatTarihi { get; set; }
        public bool AktifPasif { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        [DataType(DataType.Text)]
        public PersonelDurumu PersonelDurumu { get; set; }
    }
}