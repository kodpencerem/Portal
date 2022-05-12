using Microsoft.AspNetCore.Identity;

namespace VedasPortal.Entities.Models.User
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
