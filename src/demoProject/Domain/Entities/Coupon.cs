using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Coupon : Entity<int>
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DiscountType { get; set; } = string.Empty;
    public int DiscountValue { get; set; }
    public int MinimumPurchase { get; set; }
    public bool ApplicableToAllShops { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public int UsageLimit { get; set; } 
    public bool IsVerified { get; set; }
}

