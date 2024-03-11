using Core.Application.Responses;

namespace Application.Features.ProductSizes.Commands.Update;

public class UpdatedProductSizeResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int QuantityInStock { get; set; }
}