using Core.Application.Responses;

namespace Application.Features.CustomerWishes.Commands.Update;

public class UpdatedCustomerWishResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}