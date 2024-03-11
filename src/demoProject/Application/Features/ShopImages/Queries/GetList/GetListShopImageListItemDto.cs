using Core.Application.Dtos;

namespace Application.Features.ShopImages.Queries.GetList;

public class GetListShopImageListItemDto : IDto
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; }
}