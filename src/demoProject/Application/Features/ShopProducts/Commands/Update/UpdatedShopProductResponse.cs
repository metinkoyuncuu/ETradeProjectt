using Core.Application.Responses;

namespace Application.Features.ShopProducts.Commands.Update;

public class UpdatedShopProductResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShopId { get; set; }
}