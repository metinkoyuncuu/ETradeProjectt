using Core.Application.Responses;

namespace Application.Features.ShopSellers.Queries.GetById;

public class GetByIdShopSellerResponse : IResponse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int SellerId { get; set; }
}