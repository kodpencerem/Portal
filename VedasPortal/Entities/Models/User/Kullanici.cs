using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Entities.Models.User
{

    public class Kullanici : IdentityUser
    {
        
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;
        public int? ToplantiId { get; set; }
        public Toplanti Toplanti { get; set; }

        public ICollection<IdentityRole> Roller { get; set; }
    }
}