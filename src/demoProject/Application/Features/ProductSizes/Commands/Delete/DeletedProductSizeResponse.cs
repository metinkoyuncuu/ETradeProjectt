using Core.Application.Responses;

namespace Application.Features.ProductSizes.Commands.Delete;

public class DeletedProductSizeResponse : IResponse
{
    public int Id { get; set; }
}