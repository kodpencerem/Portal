using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Dosya
{
    public class Dosya : BaseEntity
    {

        public string Adi { get; set; }
        public string Yolu { get; set; }

        public string Uzanti { get; set; }

        public string Aciklama { get; set; }
        [StringLength(30)]
        public string Boyutu { get; set; }

        [DataType(DataType.Text)]
        public DosyaKategori Kategori { get; set; }
        public bool AktifPasif { get; set; } = true;

        public ICollection<Etkinlik.Etkinlik> Etkinlik { get; set; }
        public ICollection<Video.Video> Video { get; set; }
    }

    public enum DosyaKategori
    {
        Docx,
        Xlsx,
        Pdf,
        Zip,
        Rar,
        Mp4,
        Mkv,
        Pub,
        Pptx,
    }
}
