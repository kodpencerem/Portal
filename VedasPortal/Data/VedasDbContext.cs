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

        public DbSet<Models.Anket.Models.Survey> Anket { get; set; }
        public DbSet<SurveyOption> AnketSecenek { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Survey>(e =>
            {
                e.Property(p => p.SurveyId).IsRequired().ValueGeneratedOnAdd();
                e.HasKey(p => p.SurveyId);
                e.Property(p => p.Description).HasMaxLength(255);
                e.Property(p => p.SurveyName).HasMaxLength(50).IsRequired();
                e.Property(p => p.CreatedOn).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Survey>().HasMany(e => e.SurveyOptions).WithOne(e => e.Survey).HasForeignKey(e => e.Fk_SurveyId);

            modelBuilder.Entity<SurveyOption>(e =>
            {
                e.Property(p => p.SurveyOptionId).IsRequired().ValueGeneratedOnAdd();
                e.HasKey(p => p.SurveyOptionId);
                e.Property(p => p.TotalVotes).IsRequired();
                e.Property(p => p.ImagePath).HasMaxLength(255);
                e.Property(p => p.Description).HasMaxLength(255).IsRequired();

            });
        }

    }
}
