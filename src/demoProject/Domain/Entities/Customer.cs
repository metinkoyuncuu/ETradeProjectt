using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Customer : Entity<int>
{
    public string PhoneNumber { get; set; } = string.Empty;
    public float Balance { get; set; }
    public DateTime BirthDate { get; set; }
    public int ImageId { get; set; }
    public int GenderId { get; set; }
    public int UserId { get; set; }
    public virtual Gender? Gender { get; set; }
    public virtual User? User { get; set; }
    public virtual Image? Image { get; set; }
    public virtual ICollection<CustomerAddress>? CustomerAddresses { get; set; }
    public virtual ICollection<CustomerWish>? CustomerWishes  { get; set; }
    public virtual ICollection<CustomerCart>? CustomerCarts { get; set; }
    public virtual ICollection<CustomerCompare>? CustomerCompares { get; set; }
    public virtual ICollection<CustomerCoupon>? CustomerCoupons { get; set; }
    public virtual ICollection<CustomerCreditCard>? CustomerCreditCards { get; set; }
}
