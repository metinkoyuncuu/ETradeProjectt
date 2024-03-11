using Core.Application.Responses;

namespace Application.Features.CustomerWishes.Commands.Delete;

public class DeletedCustomerWishResponse : IResponse
{
    public int Id { get; set; }
}