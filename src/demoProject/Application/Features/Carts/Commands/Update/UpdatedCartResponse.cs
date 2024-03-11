using Core.Application.Responses;

namespace Application.Features.Carts.Commands.Update;

public class UpdatedCartResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
}