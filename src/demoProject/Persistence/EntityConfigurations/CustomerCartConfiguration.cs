using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCartConfiguration : IEntityTypeConfiguration<CustomerCart>
{
    public void Configure(EntityTypeBuilder<CustomerCart> builder)
    {
        builder.ToTable("CustomerCarts").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.CustomerId).HasColumnName("CustomerId");
        builder.Property(cc => cc.ProductId).HasColumnName("ProductId");
        builder.Property(cc => cc.CartId).HasColumnName("CartId");
        builder.Property(cc => cc.IsSelected).HasColumnName("IsSelected");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}