using Core.Application.Responses;

namespace Application.Features.OrderProducts.Commands.Delete;

public class DeletedOrderProductResponse : IResponse
{
    public int Id { get; set; }
}