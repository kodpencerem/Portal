using System.Collections.Generic;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class ToplantiMerkezi : BaseEntity
    {
        public ToplantiMerkezi()
        {
            ToplantiOdalari = new List<ToplantiOdasi>();
            ToplantiNotlari = new List<ToplantiNotu.ToplantiNotu>();
        }
        public string Kod { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int Kapasite { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool VideoKonferansMi { get; set; } = true;
        public bool RezervDurumu { get; set; }
        public ICollection<ToplantiNotu.ToplantiNotu> ToplantiNotlari { get; set; }
        public ICollection<ToplantiOdasi> ToplantiOdalari { get; set; }
    }
}