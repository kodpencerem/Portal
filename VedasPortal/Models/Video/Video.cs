using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Video
{
    public class Video: BaseEntity
    {
        public virtual Dosya.Dosya Dosya { get; set; }
        public string Baslik { get; set; }

        [NotMapped]
        public List<string> Yorumlar { get; set; } = new List<string>();
    }
}
