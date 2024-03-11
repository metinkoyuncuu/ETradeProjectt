using Core.Application.Responses;

namespace Application.Features.Carts.Commands.Create;

public class CreatedCartResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
}