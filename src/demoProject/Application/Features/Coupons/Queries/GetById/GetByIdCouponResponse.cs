using Core.Application.Responses;

namespace Application.Features.Coupons.Queries.GetById;

public class GetByIdCouponResponse : IResponse
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string DiscountType { get; set; }
    public int DiscountValue { get; set; }
    public int MinimumPurchase { get; set; }
    public bool ApplicableToAllShops { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UsageLimit { get; set; }
    public bool IsVerified { get; set; }
}