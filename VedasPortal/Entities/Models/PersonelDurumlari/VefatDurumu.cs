using System;

namespace VedasPortal.Entities.Models.PersonelDurumlari
{
    public class VefatDurumu
    {
        public string AdSoyad { get; set; }
        public string TelefonNo { get; set; }
        public string YakinlikDerecesi { get; set; }
        public string YakininAdSoyadi { get; set; }
        public DateTime? VefatTarihi { get; set; }
        public bool AktifPasif { get; set; }
    }
}
