using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.PersonelDurumlari
{
    public class PersonelDurum : Base.BaseEntity
    {
        public string AdSoyad { get; set; }
        public string TelefonNo { get; set; }
        public string Aciklama { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string Adres { get; set; }
        public string EMail { get; set; }
        public string BasladigiGorev { get; set; }
        public string GorevDegisikligi { get; set; }
        public string TemsilcilikAdi { get; set; }
        [DataType(DataType.Text)]
        public Birimler Birimler { get; set; }
        public DateTime IseBaslangicTarihi { get; set; }
        public DateTime IsDegisiklikTarihi { get; set; }
        public DateTime IstenAyrilisTarihi { get; set; }
        public string AyrilisNedeni { get; set; }
        public bool AktifPasif { get; set; }
        public bool AnasayfadaGoster { get; set; } = true;
        [DataType(DataType.Text)]
        public PersonelDurumu PersonelDurumu { get; set; }
        public ICollection<Dosya.ImageFile> ImageFile { get; set; }
        public ICollection<Egitim.Egitim> Egitim { get; set; }
    }
}