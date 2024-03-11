using Core.Application.Responses;

namespace Application.Features.ShopSellers.Commands.Create;

public class CreatedShopSellerResponse : IResponse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int SellerId { get; set; }
}