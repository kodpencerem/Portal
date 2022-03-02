using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VedasPortal.Models.ToplantiTakvimi.Konfigurasyon
{
    public class ToplantiTakvimKonfigurasyon : IEntityTypeConfiguration<ToplantiTakvimi>
    {
        public void Configure(EntityTypeBuilder<ToplantiTakvimi> builder)
        {
            builder.Property(x => x.Adi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Kod)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(300);
            
        }
    }
}
