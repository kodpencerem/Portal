using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Dokuman
{
    public class DosyaYukle : BaseEntity
    {

        public string DosyaTipi { get; set; }
        public string DosyaAdi { get; set; }
        public string DosyaYolu { get; set; }

        public string UzantiBilgisi { get; set; }

        public string Aciklama { get; set; }
        public byte[] DosyaBoyutu { get; set; }

        public int DosyaKategoriId { get; set; }
        [ForeignKey("DosyaKategoriId")]
        public DosyaKategori DosyaKategori { get; set; }
    }


}
