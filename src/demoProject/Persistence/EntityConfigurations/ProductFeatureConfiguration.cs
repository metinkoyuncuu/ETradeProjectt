using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.ToTable("ProductFeatures").HasKey(pf => pf.Id);

        builder.Property(pf => pf.Id).HasColumnName("Id").IsRequired();
        builder.Property(pf => pf.ProductId).HasColumnName("ProductId");
        builder.Property(pf => pf.Header).HasColumnName("Header");
        builder.Property(pf => pf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pf => pf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pf => pf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pf => !pf.DeletedDate.HasValue);
    }
}