using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VedasPortal.Entities.Models.ToplantiTakvimi.Konfigurasyon
{
    public class ToplantiOdasiKonfigurasyon : IEntityTypeConfiguration<ToplantiOdasi>
    {
        public void Configure(EntityTypeBuilder<ToplantiOdasi> builder)
        {
            builder.Property(x => x.Adi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Kod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(300);
            builder.Property(x => x.Kapasite)
                .HasMaxLength(100);

            builder.HasOne(e => e.ToplantiMerkezi).WithMany(r => r.ToplantiOdalari);
        }
    }
}
