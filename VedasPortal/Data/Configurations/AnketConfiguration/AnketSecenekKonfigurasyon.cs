using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.Anket;

namespace VedasPortal.Data.Configurations.AnketConfiguration
{
    public class AnketSecenekKonfigurasyon : IEntityTypeConfiguration<AnketSecenek>
    {
        public void Configure(EntityTypeBuilder<AnketSecenek> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ToplamKatilim).IsRequired();
            builder.Property(x => x.Resim).HasMaxLength(255);
            builder.Property(x => x.Aciklama).HasMaxLength(255).IsRequired();
        }
    }
}