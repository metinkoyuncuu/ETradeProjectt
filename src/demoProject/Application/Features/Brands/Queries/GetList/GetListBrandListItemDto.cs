using Core.Application.Dtos;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}