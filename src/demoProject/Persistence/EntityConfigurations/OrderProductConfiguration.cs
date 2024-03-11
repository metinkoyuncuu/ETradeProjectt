using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProducts").HasKey(op => op.Id);

        builder.Property(op => op.Id).HasColumnName("Id").IsRequired();
        builder.Property(op => op.OrderId).HasColumnName("OrderId");
        builder.Property(op => op.ProductId).HasColumnName("ProductId");
        builder.Property(op => op.Status).HasColumnName("Status");
        builder.Property(op => op.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(op => op.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(op => op.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
    }
}