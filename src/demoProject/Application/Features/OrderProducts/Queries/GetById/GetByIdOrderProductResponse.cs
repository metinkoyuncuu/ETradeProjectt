using Core.Application.Responses;

namespace Application.Features.OrderProducts.Queries.GetById;

public class GetByIdOrderProductResponse : IResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }
}