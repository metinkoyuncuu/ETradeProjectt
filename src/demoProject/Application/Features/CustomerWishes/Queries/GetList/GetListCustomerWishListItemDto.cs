using Core.Application.Dtos;

namespace Application.Features.CustomerWishes.Queries.GetList;

public class GetListCustomerWishListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}