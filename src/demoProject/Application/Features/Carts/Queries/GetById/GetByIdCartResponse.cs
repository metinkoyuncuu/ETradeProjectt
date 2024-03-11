using Core.Application.Responses;

namespace Application.Features.Carts.Queries.GetById;

public class GetByIdCartResponse : IResponse
{
    public int Id { get; set; }
    public int CouponId { get; set; }
}