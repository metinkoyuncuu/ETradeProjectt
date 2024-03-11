using Core.Application.Responses;

namespace Application.Features.CustomerCarts.Commands.Create;

public class CreatedCustomerCartResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }
}