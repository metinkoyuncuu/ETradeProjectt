using Core.Application.Responses;

namespace Application.Features.Orders.Queries.GetById;

public class GetByIdOrderResponse : IResponse
{
    public int Id { get; set; }
    public float TotalPrice { get; set; }
    public string OrderStatus { get; set; }
    public string PaymentMethod { get; set; }
    public int ShopId { get; set; }
    public int? CustomerId { get; set; }
    public int? CartId { get; set; }
}