using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ReviewImageConfiguration : IEntityTypeConfiguration<ReviewImage>
{
    public void Configure(EntityTypeBuilder<ReviewImage> builder)
    {
        builder.ToTable("ReviewImages").HasKey(ri => ri.Id);

        builder.Property(ri => ri.Id).HasColumnName("Id").IsRequired();
        builder.Property(ri => ri.ProductReviewId).HasColumnName("ProductReviewId");
        builder.Property(ri => ri.ImageId).HasColumnName("ImageId");
        builder.Property(ri => ri.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ri => ri.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ri => ri.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ri => !ri.DeletedDate.HasValue);
    }
}