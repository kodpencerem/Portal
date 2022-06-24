using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VedasPortal.Entities.Models.User
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;
        public ICollection<Anket.Anket> Anket { get; set; }
    }
}