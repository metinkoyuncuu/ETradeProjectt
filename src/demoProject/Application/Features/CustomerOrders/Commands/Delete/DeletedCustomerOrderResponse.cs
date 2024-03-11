using Core.Application.Responses;

namespace Application.Features.CustomerOrders.Commands.Delete;

public class DeletedCustomerOrderResponse : IResponse
{
    public int Id { get; set; }
}