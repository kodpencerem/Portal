using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.DuzelticiFaaliyet
{
    public class DuzelticiFaaliyet : BaseEntity
    {
        public string FaaliyetGurupAdi { get; set; }
        public string IstekFaaliyetKonusu { get; set; }
        public string Aciklama { get; set; }
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