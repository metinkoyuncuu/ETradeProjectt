using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdatedProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }
}