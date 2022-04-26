using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.User
{

    public class Kullanici : IdentityUser
    {
        
        public string Resim { get; set; }
        public string AdSoyad { get; set; }
        public string TelefonNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Adres { get; set; }
        public string BasladigiGorev { get; set; }
        public string TemsilcilikAdi { get; set; }
        [DataType(DataType.Text)]
        public Birimler? Birimler { get; set; }
        public DateTime? IseBaslangicTarihi { get; set; }
        public DateTime? IstenAyrilisTarihi { get; set; }
        public DateTime? VefatTarihi { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;
        public string AyrilisNedeni { get; set; }
        public string YakinlikDerecesi { get; set; }
        public int? ToplantiId { get; set; }
        public Toplanti Toplanti { get; set; }
        
        [DataType(DataType.Text)]
        public KullaniciDurum? KullaniciDurum { get; set; }
    }    
}