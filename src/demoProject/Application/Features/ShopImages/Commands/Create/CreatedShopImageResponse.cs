using Core.Application.Responses;

namespace Application.Features.ShopImages.Commands.Create;

public class CreatedShopImageResponse : IResponse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; }
}