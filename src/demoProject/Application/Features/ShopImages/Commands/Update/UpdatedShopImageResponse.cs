using Core.Application.Responses;

namespace Application.Features.ShopImages.Commands.Update;

public class UpdatedShopImageResponse : IResponse
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; }
}