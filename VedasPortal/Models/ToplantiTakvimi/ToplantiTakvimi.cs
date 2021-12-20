using System;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.ToplantiTakvimi
{
    public class ToplantiTakvimi: BaseEntity
    {
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string ToplantiBasligi { get; set; }
        public string RenkBilgisi { get; set; }

    }
}
