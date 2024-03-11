using Core.Application.Responses;

namespace Application.Features.Coupons.Commands.Delete;

public class DeletedCouponResponse : IResponse
{
    public int Id { get; set; }
}