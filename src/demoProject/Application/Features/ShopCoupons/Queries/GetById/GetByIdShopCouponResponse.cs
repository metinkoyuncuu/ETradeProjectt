using Core.Application.Responses;

namespace Application.Features.ShopCoupons.Queries.GetById;

public class GetByIdShopCouponResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public int ShopId { get; set; }
}