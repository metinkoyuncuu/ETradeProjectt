using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCompareConfiguration : IEntityTypeConfiguration<CustomerCompare>
{
    public void Configure(EntityTypeBuilder<CustomerCompare> builder)
    {
        builder.ToTable("CustomerCompares").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.CustomerId).HasColumnName("CustomerId");
        builder.Property(cc => cc.ProductId).HasColumnName("ProductId");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}