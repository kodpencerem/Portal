namespace VedasPortal.Entities.Models.Video
{
    public class Yorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public bool OnaylansınMı { get; set; } = false;
        public Video Video { get; set; }
    }
}