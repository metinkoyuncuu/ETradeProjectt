using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerOrderConfiguration : IEntityTypeConfiguration<CustomerOrder>
{
    public void Configure(EntityTypeBuilder<CustomerOrder> builder)
    {
        builder.ToTable("CustomerOrders").HasKey(co => co.Id);

        builder.Property(co => co.Id).HasColumnName("Id").IsRequired();
        builder.Property(co => co.CustomerId).HasColumnName("CustomerId");
        builder.Property(co => co.OrderId).HasColumnName("OrderId");
        builder.Property(co => co.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(co => co.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(co => co.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(co => !co.DeletedDate.HasValue);
    }
}