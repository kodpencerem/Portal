using System;

namespace VedasPortal.Entities.Models.Video
{
    public class Yorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public DateTime YorumTarihi { get; set; } = DateTime.Now;
        public bool OnaylansınMı { get; set; } = false;
        public int? VideoId { get; set; }
        public Video Video { get; set; }
    }
}