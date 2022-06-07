using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.Dosya
{
    public class Vidyo:Base.BaseEntity
    {
        public string Adi { get; set; }
        public string AltBaslik { get; set; }
        public string Yolu { get; set; }
        public string Uzanti { get; set; }
        public string Aciklama { get; set; }
        public long VideoUzunluk { get; set; }
        [StringLength(30)]
        public string Boyutu { get; set; }
        public DosyaKategori? Kategori { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool IzlenmeDurumu { get; set; }
        [DataType(DataType.Text)]
        public VideoKategori? VideoKategori { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public int? EgitimId { get; set; }
        public Egitim.Egitim Egitim { get; set; }
        public virtual ICollection<Yorum.Yorum> Yorum { get; set; }
    }
}