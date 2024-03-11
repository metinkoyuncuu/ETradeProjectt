using Core.Application.Responses;

namespace Application.Features.ShopCoupons.Commands.Update;

public class UpdatedShopCouponResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public int ShopId { get; set; }
}