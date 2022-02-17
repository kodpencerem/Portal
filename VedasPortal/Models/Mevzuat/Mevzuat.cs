using System;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;
using VedasPortal.Models.Video;

namespace VedasPortal.Models.Mevzuat
{
    public class Mevzuat : BaseEntity
    {
        public Dosya.Dosya Dosya { get; set; }
        public int No { get; set; }
        public string Adi { get; set; }

        public string Aciklama { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }
        public bool AktifPasif { get; set; } = true;

        [DataType(DataType.Text)]
        public MevzuatKategori Kategori { get; set; }

        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
    }

    public enum MevzuatKategori
    {
        Kararname,
        KanunHukmundeKararname,
        CumhurBaskanligiKararname,
        Tuzuk,
        Kanun,
        Yonetmelik,
        Genelge,
        Teblig
    }
}
