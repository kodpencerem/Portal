using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Video
{
    public class Video : BaseEntity
    {
        public virtual Dosya.Dosya Dosya { get; set; }
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
        [NotMapped]
        public List<string> Yorumlar { get; set; } = new List<string>();
        public HaberDuyuru.HaberDuyuru HaberDuyuru { get; set; }
        public Etkinlik.Etkinlik Etkinlik { get; set; }
        public ICollection<VideoYorum> VideoYorumlari { get; set; }
    }
    public enum VideoKategori
    {
        Genel,
        Egitim,
        Roportaj,
        Belgesel
    }
}