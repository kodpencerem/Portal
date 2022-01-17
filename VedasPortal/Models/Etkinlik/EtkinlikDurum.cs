using VedasPortal.Models.Base;

namespace VedasPortal.Models.Etkinlik
{
    public class EtkinlikDurum : BaseEntity
    {
        public int EtkinlikNo { get; set; }
        public string EtkinlikResmi { get; set; }
        public string EtkinlikAdi { get; set; }
        public string EtkinlikAciklama { get; set; }

        public string EtkinlikBaslangicTarihi { get; set; }

        public string EtkinlikBitisTarihi { get; set; }

    }
}
