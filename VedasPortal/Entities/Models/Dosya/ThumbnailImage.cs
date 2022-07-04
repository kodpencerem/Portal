namespace VedasPortal.Entities.Models.Dosya
{
    public class ThumbnailImage
    {
        public string Src { get; set; }
        public int PageNumber { get; set; }

        public ThumbnailImage(int pageNumber, string src)
        {
            PageNumber = pageNumber;
            Src = src;
        }
    }
}
