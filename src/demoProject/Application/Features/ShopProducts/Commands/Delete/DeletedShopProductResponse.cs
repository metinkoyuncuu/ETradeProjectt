using Core.Application.Responses;

namespace Application.Features.ShopProducts.Commands.Delete;

public class DeletedShopProductResponse : IResponse
{
    public int Id { get; set; }
}