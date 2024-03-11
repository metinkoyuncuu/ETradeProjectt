using Core.Application.Responses;

namespace Application.Features.Carts.Commands.Delete;

public class DeletedCartResponse : IResponse
{
    public int Id { get; set; }
}