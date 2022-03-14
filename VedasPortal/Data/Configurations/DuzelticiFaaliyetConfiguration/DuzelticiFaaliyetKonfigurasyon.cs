using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;

namespace VedasPortal.Data.Configurations.DuzelticiFaaliyetConfiguration
{
    public class DuzelticiFaaliyetKonfigurasyon : IEntityTypeConfiguration<DuzelticiFaaliyet>
    {
        public void Configure(EntityTypeBuilder<DuzelticiFaaliyet> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.FaaliyetGurupAdi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.BildirimTarihi).IsRequired().HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.IstekFaaliyetKonusu).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KonuEtiketi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.LokasyonBilgisi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasMany(x => x.Resim).WithOne(x => x.DuzelticiFaaliyet).OnDelete(DeleteBehavior.NoAction); // Navigation Propert

        }
    }
}
