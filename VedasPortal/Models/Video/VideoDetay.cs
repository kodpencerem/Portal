using System.Collections.Generic;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Video
{
    public class VideoDetay: BaseEntity
    {
        public string UrlAdres { get; set; }
        public string VideoBasligi { get; set; }
        public List<string> Yorumlar { get; set; } = new List<string>();
    }
}
