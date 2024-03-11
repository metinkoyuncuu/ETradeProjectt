using Core.Application.Dtos;

namespace Application.Features.ProductSizes.Queries.GetList;

public class GetListProductSizeListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int QuantityInStock { get; set; }
}