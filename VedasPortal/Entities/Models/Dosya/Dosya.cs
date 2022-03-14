using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Etkinlik;

namespace VedasPortal.Entities.Models.Dosya
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
        public Etkinlik.Etkinlik Etkinlik { get; set; }
        public DuzelticiFaaliyet.DuzelticiFaaliyet DuzelticiFaaliyet { get; set; }
        public ICollection<Video.Video> Video { get; set; }
        public HaberDuyuru.HaberDuyuru HaberDuyuru { get; set; }
        public ICollection<Katilimci> Katilimci { get; set; }
        public IKUygulama.IkUygulama IKUygulama { get; set; }
        public Mevzuat.Mevzuat Mevzuat { get; set; }
        public Oneri.Oneri Oneri { get; set; }
        public ToplantiTakvimi.ToplantiNotu.ToplantiNotu ToplantiNotu { get; set; }
        
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