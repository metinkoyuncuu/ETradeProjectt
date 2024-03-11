using Core.Application.Responses;

namespace Application.Features.ShopProducts.Queries.GetById;

public class GetByIdShopProductResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShopId { get; set; }
}