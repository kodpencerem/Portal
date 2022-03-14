using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Data.Configurations.DosyaConfiguration
{
    public class DosyaKonfigurasyon : IEntityTypeConfiguration<Dosya>
    {
        public void Configure(EntityTypeBuilder<Dosya> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Adi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.Uzanti).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Yolu).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.Boyutu).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasOne(x => x.Etkinlik).WithMany(x => x.Kapak).OnDelete(DeleteBehavior.NoAction); // Navigation Propert
            builder.HasMany(x => x.Video).WithOne(x => x.Dosya).OnDelete(DeleteBehavior.NoAction); // Navigation Propert
        }
    }
}
