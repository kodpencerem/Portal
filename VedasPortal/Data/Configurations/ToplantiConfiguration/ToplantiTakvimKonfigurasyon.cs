using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.ToplantiTakvimi;

namespace VedasPortal.Data.Configurations.ToplantiConfiguration
{
    public class ToplantiTakvimKonfigurasyon : IEntityTypeConfiguration<Entities.Models.ToplantiTakvimi.Toplanti>
    {
        public void Configure(EntityTypeBuilder<Entities.Models.ToplantiTakvimi.Toplanti> builder)
        {
            //builder.Property(x => x.Adi)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //builder.Property(x => x.Kod)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //builder.Property(x => x.Aciklama)
            //    .HasMaxLength(300);

            //builder.HasMany(x => x.ToplantiOdasi).WithOne(x => x.ToplantiTakvimi);
        }
    }
}
