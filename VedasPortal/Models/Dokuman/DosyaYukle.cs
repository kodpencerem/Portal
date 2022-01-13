using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Dokuman
{
    public class DosyaYukle : BaseEntity
    {

        public string VarsayilanDosyaDegeri { get; set; }
        public string DosyaTipi { get; set; }
        public string DosyaAdi { get; set; }
        public string DosyaYolu { get; set; }

        public bool DuyurudaOlsunMu { get; set; }

        public bool HaberdeOlsunMu { get; set; }

        public int DosyaKategoriId { get; set; }
        [ForeignKey("DosyaKategoriId")]
        public DosyaKategori DosyaKategori { get; set; }

    }
}
