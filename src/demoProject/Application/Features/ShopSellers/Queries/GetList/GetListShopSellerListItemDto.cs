using Core.Application.Dtos;

namespace Application.Features.ShopSellers.Queries.GetList;

public class GetListShopSellerListItemDto : IDto
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int SellerId { get; set; }
}