using Microsoft.AspNetCore.Identity;
using System;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Entities.Models.User
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? SonGirisBilgisi { get; set; }
        public bool? AktifEdilsinMi { get; set; } = true;
        public int? ToplantiId { get; set; }
        public Toplanti Toplanti { get; set; }
    }
}