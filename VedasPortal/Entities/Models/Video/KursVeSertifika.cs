using System;

namespace VedasPortal.Entities.Models.Video
{
    public class KursVeSertifika : Base.BaseEntity
    {
        public string VerenKurum { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public string GecerlilikSuresi { get; set; }
        public DateTime SertifikaVerilisTarihi { get; set; }
        public string SertifikaKodu { get; set; }
        public string SertifikaBaslik { get; set; }
        public string SertifikaUrlAdres { get; set; }
    }
}
