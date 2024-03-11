using Core.Application.Responses;

namespace Application.Features.ShopSellers.Commands.Update;

public class UpdatedShopSellerResponse : IResponse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int SellerId { get; set; }
}