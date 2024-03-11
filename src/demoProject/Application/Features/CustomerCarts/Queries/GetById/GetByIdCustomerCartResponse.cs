using Core.Application.Responses;

namespace Application.Features.CustomerCarts.Queries.GetById;

public class GetByIdCustomerCartResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }
}