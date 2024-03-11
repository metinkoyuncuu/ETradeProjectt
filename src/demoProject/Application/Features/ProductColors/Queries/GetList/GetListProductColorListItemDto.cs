using Core.Application.Dtos;

namespace Application.Features.ProductColors.Queries.GetList;

public class GetListProductColorListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int ImageId { get; set; }
}