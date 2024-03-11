using Core.Application.Responses;

namespace Application.Features.CustomerCarts.Commands.Update;

public class UpdatedCustomerCartResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }
}