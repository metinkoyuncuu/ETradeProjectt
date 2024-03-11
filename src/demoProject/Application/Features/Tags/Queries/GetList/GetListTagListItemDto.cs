using Core.Application.Dtos;

namespace Application.Features.Tags.Queries.GetList;

public class GetListTagListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}