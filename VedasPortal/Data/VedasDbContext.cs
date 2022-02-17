using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VedasPortal.Models;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.DuzelticiFaaliyet;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Models.Video;

namespace VedasPortal.Data
{
    public class VedasDbContext : IdentityDbContext
    {
        public VedasDbContext(DbContextOptions<VedasDbContext> options)
            : base(options)
        {
        }

        public DbSet<HaberDuyuru> HaberDuyuru { get; set; }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<Rehber> Rehber { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Katilimci> Katilimci { get; set; }
        public DbSet<DuzelticiFaaliyet> DuzelticiFaaliyet { get; set; }

        public DbSet<Egitim> Egitim { get; set; }

    }
}
