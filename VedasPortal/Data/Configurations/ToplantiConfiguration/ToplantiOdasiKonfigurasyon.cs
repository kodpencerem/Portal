using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Data.Configurations.ToplantiConfiguration
{
    public class ToplantiOdasiKonfigurasyon : IEntityTypeConfiguration<ToplantiOdasi>
    {
        public void Configure(EntityTypeBuilder<ToplantiOdasi> builder)
        {
            builder.Property(x => x.Adi)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Kod)
                .HasMaxLength(50);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(300);
            builder.Property(x => x.Kapasite)
                .HasMaxLength(100);
            //builder.HasOne(x => x.ToplantiMerkezi).WithMany(x => x.ToplantiOdalari);
        }
    }
}
