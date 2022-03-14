using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.Mevzuat;

namespace VedasPortal.Data.Configurations.MevzuatConfiguration
{
    public class OneriKonfigurasyon : IEntityTypeConfiguration<Mevzuat>
    {
        public void Configure(EntityTypeBuilder<Mevzuat> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Adi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Birimler).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasMany(x => x.Dosya).WithOne(x => x.Mevzuat).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
        }
    }
}
