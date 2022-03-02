using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VedasPortal.Models;
using VedasPortal.Models.Anket.Models;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.DuzelticiFaaliyet;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Models.IKUygulama;
using VedasPortal.Models.Mevzuat;
using VedasPortal.Models.Oneri;
using VedasPortal.Models.ToplantiTakvimi;
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
        public DbSet<Mevzuat> Mevzuat { get; set; }
        public DbSet<Egitim> Egitim { get; set; }
        public DbSet<Oneri> Oneri { get; set; }
        public DbSet<IkUygulama> IkUygulama { get; set; }
        public DbSet<ToplantiTakvimi> ToplantiTakvimi { get; set; }
        public DbSet<Models.Anket.Models.Anket> Anket { get; set; }
        public DbSet<AnketSecenek> AnketSecenek { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Model Builder Anket
            modelBuilder.Entity<Anket>(e =>
            {
                e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                e.HasKey(p => p.Id);
                e.Property(p => p.Aciklama).HasMaxLength(255);
                e.Property(p => p.Adi).HasMaxLength(50).IsRequired();
                e.Property(p => p.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Anket>().HasMany(e => e.AnketSecenek).WithOne(e => e.Anket).HasForeignKey(e => e.Fk_AnketId);

            //Model Builder Anket Soru Şıkları
            modelBuilder.Entity<AnketSecenek>(e =>
            {
                e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                e.HasKey(p => p.Id);
                e.Property(p => p.ToplamKatilim).IsRequired();
                e.Property(p => p.Resim).HasMaxLength(255);
                e.Property(p => p.Aciklama).HasMaxLength(255).IsRequired();

            });
        }

    }
}
