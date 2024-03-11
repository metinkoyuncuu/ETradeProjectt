using Core.Application.Dtos;

namespace Application.Features.CustomerOrders.Queries.GetList;

public class GetListCustomerOrderListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
}