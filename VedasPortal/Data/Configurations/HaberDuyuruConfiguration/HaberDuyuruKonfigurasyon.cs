using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.HaberDuyuru;

namespace VedasPortal.Data.Configurations.HaberDuyuruConfiguration
{
    public class HaberDuyuruKonfigurasyon : IEntityTypeConfiguration<HaberDuyuru>
    {
        public void Configure(EntityTypeBuilder<HaberDuyuru> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Adi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.AltBaslik).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x=>x.AnasayfadaGoster).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.SliderdaGoster).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.No).IsRequired().HasColumnType(SqlDbType.Int.ToString());
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasMany(x => x.Dosya).WithOne(x => x.HaberDuyuru).OnDelete(DeleteBehavior.NoAction); // Navigation Propert
            builder.HasMany(x => x.Video).WithOne(x => x.HaberDuyuru).OnDelete(DeleteBehavior.NoAction); // Navigation Propert

            builder.HasIndex(x => x.No);//Index property    
        }
    }
}
