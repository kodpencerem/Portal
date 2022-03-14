using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Oneri;

namespace VedasPortal.Data.Configurations.OneriConfiguration
{
    public class ToplantiNotuKonfigurasyon : IEntityTypeConfiguration<Oneri>
    {
        public void Configure(EntityTypeBuilder<Oneri> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Adi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.YapanAdiSoyadı).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.TelefonNo).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.EPosta).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.KabulDurum).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.RedNedeni).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Odul).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.Derece).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasMany(x => x.OneriDosya).WithOne(x => x.Oneri).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
        }
    }
}
