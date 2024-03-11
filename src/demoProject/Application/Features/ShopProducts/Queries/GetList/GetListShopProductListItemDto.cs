using Core.Application.Dtos;

namespace Application.Features.ShopProducts.Queries.GetList;

public class GetListShopProductListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShopId { get; set; }
}