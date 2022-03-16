namespace VedasPortal.Entities.Models.Video
{
    public class VideoYorum : Base.BaseEntity
    {
        public string Aciklama { get; set; }
        public bool OnaylansınMı { get; set; }
        public Video Video { get; set; }
    }
}