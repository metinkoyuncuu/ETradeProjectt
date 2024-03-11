using Core.Application.Responses;

namespace Application.Features.CustomerCarts.Commands.Delete;

public class DeletedCustomerCartResponse : IResponse
{
    public int Id { get; set; }
}