using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class Toplanti : Base.BaseEntity
    {
        public int PersonelId { get; set; }
        public string Kod { get; set; }

        public string Aciklama { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Toplatı konusu 250 karakterden uzun olamaz!")]
        public string Konu { get; set; }
        [Required]
        public DateTime BaslangicTarihi { get; set; }
        [Required]
        public DateTime BitisTarihi { get; set; }
        public DateTime ToplantiTarihi { get; set; } = new DateTime(1900, 1, 1);
        public int BeklenenKatilimSayisi { get; set; }
        public string Baslik { get; set; }
        public bool VideoKonferansMi { get; set; }
        public string Renk { get; set; }
        public bool AktifPasif { get; set; } = true;
        public bool AnaSayfadaGoster { get; set; }

        public ICollection<ToplantiMerkezi> ToplantiMerkezi { get; set; }
        public ICollection<ToplantiOdasi> ToplantiOdasi { get; set; }
        public ICollection<ToplantiNotu.ToplantiNotu> ToplantiNotu { get; set; }
        public ICollection<User.ApplicationUser> Kullanici { get; set; }
    }
}