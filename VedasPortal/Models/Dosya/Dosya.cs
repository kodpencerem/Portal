using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Dosya
{
    public class Dosya : BaseEntity
    {

        public string Adi { get; set; }
        public string Yolu { get; set; }

        public string Uzanti { get; set; }

        public string Aciklama { get; set; }
        [StringLength(30)]
        public string Boyutu { get; set; }
    }


}
