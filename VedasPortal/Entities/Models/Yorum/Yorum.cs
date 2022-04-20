using System;

namespace VedasPortal.Entities.Models.Yorum
{
    public class Yorum : Base.BaseEntity
    {
        public string? Aciklama { get; set; }
        public bool OnaylansınMı { get; set; } = false;
        public int? VideoId { get; set; }
        public Video.Video Video { get; set; }
    }
}