using Core.Application.Responses;

namespace Application.Features.CustomerWishes.Commands.Create;

public class CreatedCustomerWishResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}