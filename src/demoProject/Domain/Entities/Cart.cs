using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Cart : Entity<int>
{
    public int CouponId { get; set; }
    public virtual Coupon? Coupon { get; set; }
    public virtual ICollection<CustomerCart>? CustomerCarts { get; set; }
}