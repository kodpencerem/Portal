using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedasPortal.Models.Anket.Models
{
    [Table("Anket")]
    public class Anket : Base.BaseEntity
    {
        
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        public string AnketSorusu { get; set; }

        public int ToplamKatilim { get; set; }

        public bool SecilenAnketMi { get; set; }

        public int ToplamAlinanSure { get; set; }

        public bool AktifPasif { get; set; }
        public ICollection<AnketSecenek> AnketSecenek { get; set; }
    }
}
