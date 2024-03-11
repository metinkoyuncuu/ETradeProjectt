using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Queries.GetList;

public class GetListProductCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}