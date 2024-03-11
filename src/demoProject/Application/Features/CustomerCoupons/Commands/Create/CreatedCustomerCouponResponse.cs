using Core.Application.Responses;

namespace Application.Features.CustomerCoupons.Commands.Create;

public class CreatedCustomerCouponResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CouponId { get; set; }
}