using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCouponConfiguration : IEntityTypeConfiguration<CustomerCoupon>
{
    public void Configure(EntityTypeBuilder<CustomerCoupon> builder)
    {
        builder.ToTable("CustomerCoupons").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.CustomerId).HasColumnName("CustomerId");
        builder.Property(cc => cc.CouponId).HasColumnName("CouponId");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}