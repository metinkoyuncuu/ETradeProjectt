using Core.Application.Responses;

namespace Application.Features.CustomerOrders.Commands.Update;

public class UpdatedCustomerOrderResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
}