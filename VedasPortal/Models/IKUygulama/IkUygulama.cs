using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Video;

namespace VedasPortal.Models.IKUygulama
{
    public class IkUygulama : Base.BaseEntity
    {
        public string Adi { get; set; }

        public string Aciklama { get; set; }

        public bool AktifPasif { get; set; }

        public Dosya.Dosya Resim { get; set; }

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
