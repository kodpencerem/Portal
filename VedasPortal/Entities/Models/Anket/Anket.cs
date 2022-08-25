using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Anket
{
    [Table("Anket")]
    public class Anket : BaseEntity
    {
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string AnketSorusu { get; set; }
        public int ToplamKatilim { get; set; }
        public bool SecilenAnketMi { get; set; }
        public int ToplamAlinanSure { get; set; }
        public bool AktifPasif { get; set; }

        public ICollection<AnketSecenek> AnketSecenek { get; set; }
        public ICollection<AnketUser> AnketUser { get; set; }
    }
}