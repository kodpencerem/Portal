using System.Collections.Generic;

namespace VedasPortal.Models.ToplantiTakvimi
{
    public class ToplantiMerkezi : Base.BaseEntity
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
