using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using VedasPortal.Data.Toplanti;
using VedasPortal.Entities.Models;
using VedasPortal.Entities.Models.Anket;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Entities.Models.Kanban;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Entities.Models.User;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Enums;

namespace VedasPortal.Data
{
    public class VedasDbContext : IdentityDbContext<Kullanici, IdentityRole, string>
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
        public DbSet<ToplantiNotu> ToplantiNotu { get; set; }
        public DbSet<IkUygulama> IkUygulama { get; set; }
        public DbSet<Anket> Anket { get; set; }
        public DbSet<AnketSecenek> AnketSecenek { get; set; }
        public DbSet<GorevSecenek> GorevSecenek { get; set; }
        public DbSet<KursVeSertifika> KursVeSertifika { get; set; }
        public DbSet<OkulMezunBilgisi> OkulMezunBilgisi { get; set; }
        public DbSet<MailGonder> ToplantiMail { get; set; }
        public DbSet<ToplantiMerkezi> Merkez { get; set; }
        public DbSet<ToplantiOdasi> ToplantiOdasi { get; set; }
        public DbSet<PersonelDurum> PersonelDurum { get; set; }
        public DbSet<VefatDurumu> VefatDurumu { get; set; }
        public DbSet<UzmanlikAlani> UzmanlikAlani { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);           
        }
    }
}