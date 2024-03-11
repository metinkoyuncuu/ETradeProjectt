using Core.Application.Dtos;

namespace Application.Features.CustomerCoupons.Queries.GetList;

public class GetListCustomerCouponListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CouponId { get; set; }
}