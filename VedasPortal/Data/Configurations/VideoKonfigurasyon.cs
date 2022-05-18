using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedasPortal.Entities.Models.Video;

namespace VedasPortal.Data.Configurations
{
    public class VideoKonfigurasyon : IEntityTypeConfiguration<VideoClass>
    {
        public void Configure(EntityTypeBuilder<VideoClass> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Aciklama).HasMaxLength(255);
            builder.Property(x => x.Baslik).IsRequired();
            builder.Property(x => x.KayitTarihi).IsRequired().HasDefaultValueSql("getdate()");
            builder.HasMany(x => x.Yorum).WithOne(x => x.VideoClass).HasForeignKey(x => x.VideoClassId);            
        }
    }
}