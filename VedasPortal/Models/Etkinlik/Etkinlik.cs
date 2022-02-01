using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Models.Base;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.HaberDuyuru;

namespace VedasPortal.Models.Etkinlik
{
    public class Etkinlik : BaseEntity
    {
        public int No { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public virtual Dosya.Dosya Kapak { get; set; }

    }
}
