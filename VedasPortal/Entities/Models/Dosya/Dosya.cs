using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Etkinlik;

namespace VedasPortal.Entities.Models.Dosya
{
    public class Dosya : BaseEntity
    {
        public string Adi { get; set; }
        public string Yolu { get; set; }
        public string Uzanti { get; set; }
        public string Aciklama { get; set; }
        [StringLength(30)]
        public string Boyutu { get; set; }
        [DataType(DataType.Text)]
        public DosyaKategori Kategori { get; set; }
        public bool AktifPasif { get; set; } = true;
        public int HaberDuyuruId { get; set; }
        [ForeignKey("HaberDuyuruId")]
        public HaberDuyuru.HaberDuyuru HaberDuyuru { get; set; }
        public int DuzelticiFaaliyetId { get; set; }
        [ForeignKey("DuzelticiFaaliyetId")]
        public DuzelticiFaaliyet.DuzelticiFaaliyet DuzelticiFaaliyet { get; set; }
        public int EgitimId { get; set; }
        [ForeignKey("EgitimId")]
        public Egitim.Egitim Egitim { get; set; }
        public int EtkinlikId { get; set; }
        [ForeignKey("EtkinlikId")]
        public Etkinlik.Etkinlik Etkinlik { get; set; }
        public int KatilimciId { get; set; }
        [ForeignKey("KatilimciId")]
        public Katilimci Katilimci { get; set; }
        public int IkUygulamaId { get; set; }
        [ForeignKey("IkUygulamaId")]
        public IKUygulama.IkUygulama IkUygulama { get; set; }
        public int MevzuatId { get; set; }
        [ForeignKey("MevzuatId")]
        public Mevzuat.Mevzuat Mevzuat { get; set; }
        public int OneriId { get; set; }
        [ForeignKey("OneriId")]
        public Oneri.Oneri Oneri { get; set; }
        public int RehberId { get; set; }
        [ForeignKey("RehberId")]
        public Rehber Rehber { get; set; }

    }

    public enum DosyaKategori
    {
        Docx,
        Xlsx,
        Pdf,
        Zip,
        Rar,
        Mp4,
        Mkv,
        Pub,
        Pptx,
    }
}