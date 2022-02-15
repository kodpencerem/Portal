﻿using System.ComponentModel.DataAnnotations;
using VedasPortal.Models.Base;

namespace VedasPortal.Models.Etkinlik
{
    public class Etkinlik : BaseEntity
    {
        
        public int No { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public virtual Dosya.Dosya Kapak { get; set; }

        public bool SliderdaGoster { get; set; } = false;
        [DataType(DataType.Text)]
        public EtkinlikKategori Kategori { get; set; }

        public KatilimciKategori KKategori { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool AnasayfadaGoster { get; set; } = true;
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
        Tiyatro
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
        Davetli
    }
}
