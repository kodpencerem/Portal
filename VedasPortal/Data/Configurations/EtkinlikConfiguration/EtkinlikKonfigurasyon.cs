using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Etkinlik;

namespace VedasPortal.Data.Configurations.EtkinlikConfiguration
{
    public class DosyaKonfigurasyon : IEntityTypeConfiguration<Etkinlik>
    {
        public void Configure(EntityTypeBuilder<Etkinlik> builder)
        {
            //Properties
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.Adi).IsRequired().HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.BaslangicTarihi).IsRequired().HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.BitisTarihi).IsRequired().HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.KKategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.Kategori).IsRequired().HasColumnType(SqlDbType.TinyInt.ToString());
            builder.Property(x => x.AnasayfadaGoster).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.SliderdaGoster).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.AktifPasif).HasColumnType(SqlDbType.Bit.ToString());
            builder.Property(x => x.No).IsRequired().HasColumnType(SqlDbType.Int.ToString());
            builder.Property(x => x.DuzenlemeTarihi).HasColumnType(SqlDbType.Date.ToString());
            builder.Property(x => x.DuzenleyenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.KaydedenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilenKullanici).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.SilmeTarihi).HasColumnType(SqlDbType.Date.ToString());

            builder.HasMany(x => x.Kapak).WithOne(x => x.Etkinlik).OnDelete(DeleteBehavior.NoAction); // Navigation Propert
            builder.HasMany(x => x.Katilimci).WithOne(x => x.Etkinlik).OnDelete(DeleteBehavior.NoAction); // Navigation Propert

            builder.HasIndex(x => x.No);//Index property    
        }
    }
}
