using Core.Application.Dtos;

namespace Application.Features.Sizes.Queries.GetList;

public class GetListSizeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}