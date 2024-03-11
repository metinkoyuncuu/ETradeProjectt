using Core.Application.Responses;

namespace Application.Features.ShopImages.Commands.Delete;

public class DeletedShopImageResponse : IResponse
{
    public int Id { get; set; }
}