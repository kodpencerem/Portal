using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VedasPortal.Models;

namespace VedasPortal.Data
{
    public class VedasDbContext : IdentityDbContext
    {
        public VedasDbContext(DbContextOptions<VedasDbContext> options)
            : base(options)
        {
        }

		public DbSet<Duyuru> Duyurular { get; set; }

        public DbSet<DosyaKategori> DosyaKategorileri { get; set; }

        public DbSet<Rehber> PersonelRehber { get; set; }


    }
}
