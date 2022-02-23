using System.ComponentModel.DataAnnotations.Schema;

namespace VedasPortal.Models.Anket.Models
{
    [Table("AnketSecenek")]
    public class AnketSecenek : Base.BaseEntity
    {
        public int Fk_AnketId { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int ToplamKatilim { get; set; }

        public Anket Anket { get; set; }
    }
}
