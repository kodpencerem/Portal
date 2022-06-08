using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class ToplantiMerkezi : Base.BaseEntity
    {
        [Required(ErrorMessage = "Toplantı Merkezi Adi Gerekli")]
        public string Adi { get; set; }
        public virtual ICollection<ToplantiOdasi> ToplantiOdasi { get; set; }
        public virtual ICollection<ToplantiNotu.ToplantiNotu> ToplantiNotu { get; set; }
    }
}
