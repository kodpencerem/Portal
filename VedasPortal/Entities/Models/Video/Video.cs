using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Egitim;

namespace VedasPortal.Entities.Models.Video
{
    public class Video : BaseEntity
    {
        
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Aciklama { get; set; }
        public long Uzunluk { get; set; }
        public bool AktifPasif { get; set; }
        public bool IzlenmeDurumu { get; set; }
        [DataType(DataType.Text)]
        public VideoKategori Kategori { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }

        public int? HaberDuyuruId { get; set; }
        public HaberDuyuru.HaberDuyuru HaberDuyuru { get; set; }

        public int? EtkinlikId { get; set; }
        public Etkinlik.Etkinlik Etkinlik { get; set; }
        public virtual ICollection<Dosya.Dosya> Dosya { get; set; }
        public int? EgitimId { get; set; }
        public Egitim.Egitim Egitim { get; set; }
        public virtual ICollection<Yorum.Yorum> Yorum { get; set; } 
    }
    public enum VideoKategori
    {
        Genel,
        Egitim,
        Roportaj,
        Belgesel
    }
}