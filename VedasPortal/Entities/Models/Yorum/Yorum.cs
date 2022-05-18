namespace VedasPortal.Entities.Models.Yorum
{
    public class Yorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public bool OnaylansinMi { get; set; } = false;
        public int? VideoClassId { get; set; }
        public Video.VideoClass VideoClass { get; set; }
        public int? OneriId { get; set; }
        public Oneri.Oneri Oneri { get; set; }
    }
}