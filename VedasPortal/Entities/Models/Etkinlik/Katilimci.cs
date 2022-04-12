using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Etkinlik
{
    public class Katilimci : BaseEntity
    {
        public string AdSoyad { get; set; }
        public string EMail { get; set; }
        public string TelefonNo { get; set; }
        public bool KatilisDurumu { get; set; }
        public string KatilisNedeni { get; set; }
        public virtual ICollection<Dosya.Dosya> Dosya { get; set; }
        public int EtkinlikId { get; set; }
        [ForeignKey("EtkinlikId")]
        public Etkinlik Etkinlik { get; set; }
    }
}