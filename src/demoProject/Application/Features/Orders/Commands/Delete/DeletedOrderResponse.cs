using Core.Application.Responses;

namespace Application.Features.Orders.Commands.Delete;

public class DeletedOrderResponse : IResponse
{
    public int Id { get; set; }
}