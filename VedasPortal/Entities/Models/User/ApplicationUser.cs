using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VedasPortal.Entities.Models.User
{

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Anket = new HashSet<Anket.Anket>();
            AnketSecenek = new HashSet<Anket.AnketSecenek>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;

        public virtual ICollection<Anket.Anket> Anket { get; set; }
        public virtual ICollection<Anket.AnketSecenek> AnketSecenek { get; set; }
    }
}