using System;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.ToplantiTakvimi
{
    public class ToplantiTakvimi: BaseEntity
    {
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Adres { get; set; }
        public string Renk { get; set; }
        public bool AktifPasif { get; set; }
        public bool AnaSayfadaGoster { get; set; }

    }
}
