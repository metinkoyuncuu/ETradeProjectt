using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShopCouponConfiguration : IEntityTypeConfiguration<ShopCoupon>
{
    public void Configure(EntityTypeBuilder<ShopCoupon> builder)
    {
        builder.ToTable("ShopCoupons").HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.CouponId).HasColumnName("CouponId");
        builder.Property(sc => sc.ShopId).HasColumnName("ShopId");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);
    }
}