using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShopSellerConfiguration : IEntityTypeConfiguration<ShopSeller>
{
    public void Configure(EntityTypeBuilder<ShopSeller> builder)
    {
        builder.ToTable("ShopSellers").HasKey(ss => ss.Id);

        builder.Property(ss => ss.Id).HasColumnName("Id").IsRequired();
        builder.Property(ss => ss.ShopId).HasColumnName("ShopId");
        builder.Property(ss => ss.SellerId).HasColumnName("SellerId");
        builder.Property(ss => ss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ss => ss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ss => ss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ss => !ss.DeletedDate.HasValue);
    }
}