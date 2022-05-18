using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using VedasPortal.Entities.Models.Yorum;

namespace VedasPortal.Data.Configurations
{
    public class YorumKonfigurasyon : IEntityTypeConfiguration<Yorum>
    {
        public void Configure(EntityTypeBuilder<Yorum> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).HasMaxLength(255);
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.VideoClass).WithMany(x => x.Yorum).HasForeignKey(x => x.VideoClassId);
            builder.HasOne(x => x.Oneri).WithMany(x => x.Yorum).HasForeignKey(x => x.OneriId);
        }
    }
}