using Core.Application.Dtos;

namespace Application.Features.ProductImages.Queries.GetList;

public class GetListProductImageListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
}