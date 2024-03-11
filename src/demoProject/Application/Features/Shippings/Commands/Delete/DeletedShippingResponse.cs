using Core.Application.Responses;

namespace Application.Features.Shippings.Commands.Delete;

public class DeletedShippingResponse : IResponse
{
    public int Id { get; set; }
}