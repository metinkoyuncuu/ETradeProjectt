using Core.Application.Responses;

namespace Application.Features.CustomerCoupons.Queries.GetById;

public class GetByIdCustomerCouponResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CouponId { get; set; }
}