using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Egitim;

namespace VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu
{
    public class ToplantiNotu : BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public int? ToplantiId { get; set; }
        public Toplanti Toplanti { get; set; }
        public int? ToplantiOdasiId { get; set; }
        public ToplantiOdasi ToplantiOdasi { get; set; }
        public int? ToplantiMerkeziId { get; set; }
        public ToplantiMerkezi ToplantiMerkezi { get; set; }
        public virtual ICollection<Dosya.ImageFile> ImageFile { get; set; }
    }
}