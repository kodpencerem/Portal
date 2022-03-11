using System;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class ToplantiTakvimi : BaseEntity
    {
        public string Kod { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string Konu { get; set; }
        public DateTime ToplantiTarihi { get; set; } = new DateTime(1900, 1, 1);
        public DateTime BaslangicTarihi { get; set; } = new DateTime(1900, 1, 1);
        public DateTime BitisTarihi { get; set; } = new DateTime(1900, 1, 1);
        public string TarihDegeri { get; set; }
        public int BeklenenKatilimSayisi { get; set; }
        public string GunAdi { get; set; }
        public string ToplantiNotu { get; set; }
        public string Mesaj { get; set; }
        public string Baslik { get; set; }
        public bool VideoKonferansMi { get; set; }
        public string Renk { get; set; }
        public bool AktifPasif { get; set; }
        public bool AnaSayfadaGoster { get; set; }
        public ToplantiOdasi ToplantiOdasi { get; set; }
    }
}