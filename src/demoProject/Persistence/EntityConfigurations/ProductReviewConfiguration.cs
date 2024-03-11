using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.ToTable("ProductReviews").HasKey(pr => pr.Id);

        builder.Property(pr => pr.Id).HasColumnName("Id").IsRequired();
        builder.Property(pr => pr.ProductId).HasColumnName("ProductId");
        builder.Property(pr => pr.CustomerId).HasColumnName("CustomerId");
        builder.Property(pr => pr.Rate).HasColumnName("Rate");
        builder.Property(pr => pr.Comment).HasColumnName("Comment");
        builder.Property(pr => pr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pr => pr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pr => pr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pr => !pr.DeletedDate.HasValue);
    }
}