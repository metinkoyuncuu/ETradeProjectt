using Core.Application.Responses;

namespace Application.Features.ShopCoupons.Commands.Delete;

public class DeletedShopCouponResponse : IResponse
{
    public int Id { get; set; }
}