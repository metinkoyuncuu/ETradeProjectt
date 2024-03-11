using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.Create;

public class CreatedProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }
}