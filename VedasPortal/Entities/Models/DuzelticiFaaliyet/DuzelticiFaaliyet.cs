using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.DuzelticiFaaliyet
{
    public class DuzelticiFaaliyet : BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Faaliyet Grubu:")]
        [DataType(DataType.Text)]
        public string FaaliyetGurupAdi { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "İstenen Faaliyet:")]
        [DataType(DataType.Text)]
        public string IstekFaaliyetKonusu { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Açıklama:")]
        [DataType(DataType.Text)]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Bildirim Tarihi:")]
        [DataType(DataType.Date)]
        public DateTime BildirimTarihi { get; set; } = DateTime.Now.Date;
        public bool AktifPasif { get; set; } = true;
        public virtual ICollection<Dosya.Dosya> Resim { get; set; }
        [DataType(DataType.Text)]
        public DuzelticiFaaliyetKategori Kategori { get; set; }
        public string KonuEtiketi { get; set; }
        
        public string LokasyonBilgisi { get; set; }     
    }

    public enum DuzelticiFaaliyetKategori
    {
        CevreAydinlatma,
        KopruKavsakAydinlatma,
        ProsedurVePolitikalar,
    }
}