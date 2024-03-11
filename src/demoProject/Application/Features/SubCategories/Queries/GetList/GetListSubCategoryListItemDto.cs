using Core.Application.Dtos;

namespace Application.Features.SubCategories.Queries.GetList;

public class GetListSubCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public bool IsVerified { get; set; }
}