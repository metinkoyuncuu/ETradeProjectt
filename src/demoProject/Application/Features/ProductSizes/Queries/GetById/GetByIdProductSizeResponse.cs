using Core.Application.Responses;

namespace Application.Features.ProductSizes.Queries.GetById;

public class GetByIdProductSizeResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int QuantityInStock { get; set; }
}