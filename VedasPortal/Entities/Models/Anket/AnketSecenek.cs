using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Anket
{
    [Table("AnketSecenek")]
    public class AnketSecenek : BaseEntity
    {
        public int AnketId { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int ToplamKatilim { get; set; }
        public Anket Anket { get; set; }
    }
}