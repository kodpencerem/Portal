using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Entities.Models.Oneri
{
    public class Oneri : BaseEntity
    {
        public Dosya.Dosya OneriDosya { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }
        public bool KabulDurum { get; set; }
        public string RedNedeni { get; set; }
        public string YapanAdiSoyadı { get; set; }
        public string TelefonNo { get; set; }
        public string EPosta { get; set; }
        [DataType(DataType.Text)]
        public OnemDerecesi Derece { get; set; }
        [DataType(DataType.Text)]
        public Odul Odul { get; set; }
        [DataType(DataType.Text)]
        public OneriKategori Kategori { get; set; }
    }

    public enum OnemDerecesi
    {
        Yuksek,
        Orta,
        Dusuk
    }

    public enum Odul
    {
        Para,
        Izin,
        IndirimKuponu,
    }

    public enum OneriKategori
    {
        Proje,
        CevreAydinlatma,
        KopruVeKavsakAydinlatma,
        ProsedurVePolitikalar,
        Diger,
        IsGuvenligi,
        CalismaKosullari,
        Motivasyon,
        ElektrikUretim,
        TesisVeyaKurum,
        HizmetKalitesi,
        Rekabet,
        CalisanHaklari,
        IsVerenHaklari,
        Maliyet,
        Bilgilendirme,
        Giderler,
        Gelirler
    }
}