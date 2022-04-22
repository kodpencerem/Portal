using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Enums;

namespace VedasPortal.Entities.Models.User
{

    public class Kullanici : Base.BaseEntity
    {
        [Required]
        public string KullaniciAdi { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool AktifEdilsinMi { get; set; } = true;
        [NotMapped]
        public List<KullaniciRol> Roller { get; set; } = new List<KullaniciRol>();

        public Toplanti Toplanti { get; set; }

    }
    public class KullaniciGiris
    {
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz!")]
        public string KullaniciAdi { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrenizi giriniz!")]
        public string Sifre { get; set; }
    }
}
