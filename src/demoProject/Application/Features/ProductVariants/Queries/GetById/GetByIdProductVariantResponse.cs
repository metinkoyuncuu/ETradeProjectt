using Core.Application.Responses;

namespace Application.Features.ProductVariants.Queries.GetById;

public class GetByIdProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }
}