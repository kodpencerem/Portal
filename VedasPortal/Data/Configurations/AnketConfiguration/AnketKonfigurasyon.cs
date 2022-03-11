using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.Anket;

namespace VedasPortal.Data.Configurations.AnketConfiguration
{
    public class AnketKonfigurasyon : IEntityTypeConfiguration<Anket>
    {
        public void Configure(EntityTypeBuilder<Anket> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).HasMaxLength(255);
            builder.Property(x => x.Adi).HasMaxLength(50).IsRequired();
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasMany(x => x.AnketSecenek).WithOne(x => x.Anket).HasForeignKey(x => x.Fk_AnketId);
        }
    }
}