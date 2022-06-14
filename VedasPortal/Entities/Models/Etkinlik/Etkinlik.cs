using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Etkinlik
{
    public class Etkinlik : BaseEntity
    {
        public int No { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool SliderdaGoster { get; set; } = false;
        [DataType(DataType.Text)]
        public EtkinlikKategori Kategori { get; set; }
        public KatilimciKategori KKategori { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool AnasayfadaGoster { get; set; } = true;
        public virtual ICollection<Katilimci> Katilimci { get; set; }
        public virtual ICollection<Dosya.ImageFile> Dosya { get; set; }
    }

    public enum EtkinlikKategori
    {
        DogaYuruyusu,
        FidanDikimi,
        CevreTemizligi,
        Tanisma,
        Seminer,
        Konferans,
        Konser,
        Tiyatro,
        Etkinlik
    }

    public enum KatilimciKategori
    {
        TumPersonel,
        Scada,
        BilgiIslem,
        CagriMerkezi,
        Hukuk,
        KaliteMudurlugu,
        InsanKaynaklariPersoneli,
        SadeceKadinPersonel,
        SadeceErkekPersonel,
        Davetli
    }
}
