using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Entities.Models.User
{

    public class Kullanici : IdentityUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Source { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;
        public int? ToplantiId { get; set; }
        public Toplanti Toplanti { get; set; }        
    }
}