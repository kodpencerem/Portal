using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.User;

namespace VedasPortal.Entities.Models.Anket
{
    [Table("AnketSecenek")]
    public class AnketSecenek : BaseEntity
    {
        public int Fk_AnketId { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public int ToplamKatilim { get; set; }
        public Anket Anket { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}