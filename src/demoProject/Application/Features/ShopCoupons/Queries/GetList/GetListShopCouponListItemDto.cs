using Core.Application.Dtos;

namespace Application.Features.ShopCoupons.Queries.GetList;

public class GetListShopCouponListItemDto : IDto
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public int ShopId { get; set; }
}