using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.Delete;

public class DeletedProductVariantResponse : IResponse
{
    public int Id { get; set; }
}