using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VedasPortal.Data
{
    public class VedasDbContext : IdentityDbContext
    {
        public VedasDbContext(DbContextOptions<VedasDbContext> options)
            : base(options)
        {
        }
    }
}
