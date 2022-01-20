using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;
using VedasPortal.Models.YayinDurumlari;

namespace VedasPortal.Models.Etkinlik
{
    public class EtkinlikDurum : BaseEntity
    {
        public int EtkinlikNo { get; set; }
        public string EtkinlikResmi { get; set; }
        public string EtkinlikAdi { get; set; }
        public string EtkinlikAciklama { get; set; }

        public byte[] DosyaBoyutu { get; set; }

        public string DosyaYolu { get; set; }

        public string EtkinlikBaslangicTarihi { get; set; }

        public string EtkinlikBitisTarihi { get; set; }

        public int YayinKategoriId { get; set; }
        [ForeignKey("YayinKategoriId")]
        public YayinKategori YayinKategori { get; set; }

        

    }
}
