using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ToTable("Coupons").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Code).HasColumnName("Code");
        builder.Property(c => c.Description).HasColumnName("Description");
        builder.Property(c => c.DiscountType).HasColumnName("DiscountType");
        builder.Property(c => c.DiscountValue).HasColumnName("DiscountValue");
        builder.Property(c => c.MinimumPurchase).HasColumnName("MinimumPurchase");
        builder.Property(c => c.ApplicableToAllShops).HasColumnName("ApplicableToAllShops");
        builder.Property(c => c.StartDate).HasColumnName("StartDate");
        builder.Property(c => c.EndDate).HasColumnName("EndDate");
        builder.Property(c => c.UsageLimit).HasColumnName("UsageLimit");
        builder.Property(c => c.IsVerified).HasColumnName("IsVerified");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}