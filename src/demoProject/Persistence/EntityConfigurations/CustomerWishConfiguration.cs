using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerWishConfiguration : IEntityTypeConfiguration<CustomerWish>
{
    public void Configure(EntityTypeBuilder<CustomerWish> builder)
    {
        builder.ToTable("CustomerWishes").HasKey(cw => cw.Id);

        builder.Property(cw => cw.Id).HasColumnName("Id").IsRequired();
        builder.Property(cw => cw.CustomerId).HasColumnName("CustomerId");
        builder.Property(cw => cw.ProductId).HasColumnName("ProductId");
        builder.Property(cw => cw.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cw => cw.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cw => cw.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cw => !cw.DeletedDate.HasValue);
    }
}