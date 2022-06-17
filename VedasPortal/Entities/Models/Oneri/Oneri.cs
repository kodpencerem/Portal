using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.Oneri
{
    public class Oneri : BaseEntity
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifPasif { get; set; }
        public string RedNedeni { get; set; }
        public bool Begeni { get; set; } = false;
        public int BegeniDerecesi { get; set; }
        public string YapanAdiSoyadı { get; set; }
        public string TelefonNo { get; set; }
        public string EPosta { get; set; }
        [DataType(DataType.Text)]
        public DurumKodlari? OneriDurum { get; set; } = DurumKodlari.Degerlendiriliyor;
        [DataType(DataType.Text)]
        public OnemDerecesi Derece { get; set; }
        [DataType(DataType.Text)]
        public Odul? Odul { get; set; } = Models.Oneri.Odul.Degerlendiriliyor;
        [DataType(DataType.Text)]
        public OneriKategori Kategori { get; set; }
        public virtual ICollection<Dosya.ImageFile> ImageFile { get; set; }
        public virtual ICollection<Yorum.Yorum> Yorum { get; set; }
    }

    public enum OnemDerecesi
    {
        Yuksek,
        Orta,
        Dusuk
    }

    public enum Odul
    {
        Degerlendiriliyor,
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