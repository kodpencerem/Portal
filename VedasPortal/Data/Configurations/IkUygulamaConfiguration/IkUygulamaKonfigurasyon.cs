using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.IKUygulama;

namespace VedasPortal.Data.Configurations.IkUygulamaConfiguration
{
    public class MevzuatKonfigurasyon : IEntityTypeConfiguration<IkUygulama>
    {
        public void Configure(EntityTypeBuilder<IkUygulama> builder)
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

            builder.HasMany(x => x.Resim).WithOne(x => x.IKUygulama).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
        }
    }
}
