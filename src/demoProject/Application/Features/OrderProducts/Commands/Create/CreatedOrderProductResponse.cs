using Core.Application.Responses;

namespace Application.Features.OrderProducts.Commands.Create;

public class CreatedOrderProductResponse : IResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }
}