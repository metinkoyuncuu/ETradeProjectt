using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShopImageConfiguration : IEntityTypeConfiguration<ShopImage>
{
    public void Configure(EntityTypeBuilder<ShopImage> builder)
    {
        builder.ToTable("ShopImages").HasKey(si => si.Id);

        builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
        builder.Property(si => si.ShopId).HasColumnName("ShopId");
        builder.Property(si => si.ImageId).HasColumnName("ImageId");
        builder.Property(si => si.ImageType).HasColumnName("ImageType");
        builder.Property(si => si.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(si => si.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(si => si.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(si => !si.DeletedDate.HasValue);
    }
}