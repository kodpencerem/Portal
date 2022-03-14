using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.Etkinlik;

namespace VedasPortal.Data.Configurations.KatilimciConfiguration
{
    public class IkUygulamaKonfigurasyon : IEntityTypeConfiguration<Katilimci>
    {
        public void Configure(EntityTypeBuilder<Katilimci> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AdSoyad).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.EMail).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KatilisNedeni).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.TelefonNo).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KatilisDurumu).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasOne(x => x.Resim).WithMany(x => x.Katilimci).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
        }
    }
}
