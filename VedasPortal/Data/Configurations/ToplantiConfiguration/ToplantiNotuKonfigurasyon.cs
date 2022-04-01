using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;

namespace VedasPortal.Data.Configurations.ToplantiConfiguration
{
    public class ToplantiNotuKonfigurasyon : IEntityTypeConfiguration<ToplantiNotu>
    {
        public void Configure(EntityTypeBuilder<ToplantiNotu> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Baslik).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.AltBaslik).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Konu).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.Birimler).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            //builder.HasMany(x => x.GetDosya).WithOne(x => x.ToplantiNotu).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
            //builder.HasOne(x => x.ToplantiMerkezi).WithMany(x => x.ToplantiNotlari).OnDelete(DeleteBehavior.NoAction); // Navigation Propert 
        }
    }
}
