using Core.Application.Dtos;

namespace Application.Features.ProductVariants.Queries.GetList;

public class GetListProductVariantListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }
}