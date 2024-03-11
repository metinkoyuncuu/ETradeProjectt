using Core.Application.Responses;

namespace Application.Features.CustomerCoupons.Commands.Delete;

public class DeletedCustomerCouponResponse : IResponse
{
    public int Id { get; set; }
}