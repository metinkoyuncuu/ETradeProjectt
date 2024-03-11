using Core.Application.Responses;

namespace Application.Features.ShopProducts.Commands.Create;

public class CreatedShopProductResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShopId { get; set; }
}