using System;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.ToplantiTakvimi
{
    public class ToplantiTakvimi: BaseEntity
    {
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Baslik { get; set; }
        public string Renk { get; set; }

    }
}
