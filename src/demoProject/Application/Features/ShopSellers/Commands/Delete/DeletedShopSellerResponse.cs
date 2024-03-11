using Core.Application.Responses;

namespace Application.Features.ShopSellers.Commands.Delete;

public class DeletedShopSellerResponse : IResponse
{
    public int Id { get; set; }
}