using Core.Application.Dtos;

namespace Application.Features.CustomerCarts.Queries.GetList;

public class GetListCustomerCartListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }
}