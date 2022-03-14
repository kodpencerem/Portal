using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Video;

namespace VedasPortal.Entities.Models.IKUygulama
{
    public class IkUygulama : BaseEntity
    {
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }
        public virtual ICollection<Dosya.Dosya> Resim { get; set; }
        [DataType(DataType.Text)]
        public IkUygulamaKategori Kategori { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
    }

    public enum IkUygulamaKategori
    {
        Bordro,
        IzinGoruntulemVeBasvuru,
        IseAlmaCikarma,
        PerformansDegerlendirme,
        EgitimYonetimi,
    }
}