using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VedasPortal.Entities.Models.ToplantiTakvimi.Konfigurasyon
{
    public class ToplantiMerkeziKonfigurasyon : IEntityTypeConfiguration<ToplantiMerkezi>
    {
        public void Configure(EntityTypeBuilder<ToplantiMerkezi> builder)
        {
            builder.Property(x => x.Adi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Kod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(300);
            builder.HasMany(x => x.ToplantiOdalari).WithOne(x => x.ToplantiMerkezi);
        }
    }
}
