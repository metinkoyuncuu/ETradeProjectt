using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductFeatureTableConfiguration : IEntityTypeConfiguration<ProductFeatureTable>
{
    public void Configure(EntityTypeBuilder<ProductFeatureTable> builder)
    {
        builder.ToTable("ProductFeatureTables").HasKey(pft => pft.Id);

        builder.Property(pft => pft.Id).HasColumnName("Id").IsRequired();
        builder.Property(pft => pft.Column).HasColumnName("Column");
        builder.Property(pft => pft.Description).HasColumnName("Description");
        builder.Property(pft => pft.ProductFeatureId).HasColumnName("ProductFeatureId");
        builder.Property(pft => pft.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pft => pft.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pft => pft.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pft => !pft.DeletedDate.HasValue);
    }
}