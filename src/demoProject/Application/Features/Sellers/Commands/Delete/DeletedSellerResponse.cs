using Core.Application.Responses;

namespace Application.Features.Sellers.Commands.Delete;

public class DeletedSellerResponse : IResponse
{
    public int Id { get; set; }
}