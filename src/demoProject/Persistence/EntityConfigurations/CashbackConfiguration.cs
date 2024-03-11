using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CashbackConfiguration : IEntityTypeConfiguration<Cashback>
{
    public void Configure(EntityTypeBuilder<Cashback> builder)
    {
        builder.ToTable("Cashbacks").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.OrderId).HasColumnName("OrderId");
        builder.Property(c => c.CustomerId).HasColumnName("CustomerId");
        builder.Property(c => c.CashbackRatio).HasColumnName("CashbackRatio");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}