using Core.Application.Responses;

namespace Application.Features.CustomerOrders.Queries.GetById;

public class GetByIdCustomerOrderResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
}