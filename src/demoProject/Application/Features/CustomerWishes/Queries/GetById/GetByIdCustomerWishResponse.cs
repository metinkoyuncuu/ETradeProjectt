using Core.Application.Responses;

namespace Application.Features.CustomerWishes.Queries.GetById;

public class GetByIdCustomerWishResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}