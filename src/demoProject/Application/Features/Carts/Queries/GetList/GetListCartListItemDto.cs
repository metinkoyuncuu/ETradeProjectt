using Core.Application.Dtos;

namespace Application.Features.Carts.Queries.GetList;

public class GetListCartListItemDto : IDto
{
    public int Id { get; set; }
    public int CouponId { get; set; }
}