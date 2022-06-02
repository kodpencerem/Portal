using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Data.Configurations
{
    public class VideoKonfigurasyon : IEntityTypeConfiguration<Dosya>
    {
        public void Configure(EntityTypeBuilder<Dosya> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).HasMaxLength(255);
            builder.Property(x => x.Adi).IsRequired();
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasMany(x => x.Yorum).WithOne(x => x.Dosya).HasForeignKey(x => x.DosyaId);            
        }
    }
}