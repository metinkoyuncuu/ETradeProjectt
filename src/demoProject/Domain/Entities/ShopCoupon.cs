using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ShopCoupon: Entity<int>
{
    public int CouponId { get; set; }
    public int ShopId { get; set; }
    public virtual Coupon? Coupon { get; set; }
    public virtual Shop? Shop { get; set; }
}
