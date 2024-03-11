using Core.Application.Responses;

namespace Application.Features.ShopCoupons.Commands.Create;

public class CreatedShopCouponResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public int ShopId { get; set; }
}