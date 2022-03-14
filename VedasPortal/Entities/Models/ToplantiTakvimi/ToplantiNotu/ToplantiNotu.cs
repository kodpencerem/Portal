using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Video;

namespace VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu
{
    public class ToplantiNotu : BaseEntity
    {
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public ToplantiMerkezi ToplantiMerkezi { get; set; }
        public ICollection<Dosya.Dosya> GetDosya { get; set; }
    }
}