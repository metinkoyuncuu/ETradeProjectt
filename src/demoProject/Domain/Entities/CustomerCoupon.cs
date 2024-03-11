using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerCoupon : Entity<int>
{
    public int CustomerId { get; set; }
    public int CouponId { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Coupon? Coupon { get; set; }
}
