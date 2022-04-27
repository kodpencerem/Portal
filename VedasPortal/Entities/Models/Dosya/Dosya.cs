using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Entities.Models.User;

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
        public int? HaberDuyuruId { get; set; }
        public HaberDuyuru.HaberDuyuru HaberDuyuru { get; set; }
        public int? DuzelticiFaaliyetId { get; set; }
        public DuzelticiFaaliyet.DuzelticiFaaliyet DuzelticiFaaliyet { get; set; }
        public int? EgitimId { get; set; }
        public Egitim.Egitim Egitim { get; set; }
        public int? EtkinlikId { get; set; }
        public Etkinlik.Etkinlik Etkinlik { get; set; }
        public int? KatilimciId { get; set; }
        public Katilimci Katilimci { get; set; }
        public int? IkUygulamaId { get; set; }
        public IKUygulama.IkUygulama IkUygulama { get; set; }
        public int? MevzuatId { get; set; }
        public Mevzuat.Mevzuat Mevzuat { get; set; }
        public int? OneriId { get; set; }
        public Oneri.Oneri Oneri { get; set; }
        public int? RehberId { get; set; }
        public Rehber Rehber { get; set; }

        public int? VideoId { get; set; }
        public Video.Video Video { get; set; }

        public int? PersonelDurumId { get; set; }
        public PersonelDurum PersonelDurum { get; set; }

        public int? ToplantiNotuId { get; set; }
        public ToplantiTakvimi.ToplantiNotu.ToplantiNotu ToplantiNotu { get; set; }

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
        Jpeg,
        Jpg,
        Gif,
        Bitmap
    }
}