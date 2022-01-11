using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VedasPortal.Models;
using VedasPortal.Models.Dokuman;
using VedasPortal.Models.YayinDurumlari;

namespace VedasPortal.Data
{
    public class VedasDbContext : IdentityDbContext
    {
        public VedasDbContext(DbContextOptions<VedasDbContext> options)
            : base(options)
        {
        }

		public DbSet<Yayin> Yayinlar { get; set; }

        public DbSet<DosyaYukle> DosyaYuklemeleri { get; set; }


        public DbSet<DosyaKategori> DosyaKategorileri { get; set; }

        public DbSet<Rehber> PersonelRehber { get; set; }


    }
}
