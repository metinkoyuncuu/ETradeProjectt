using Core.Application.Dtos;

namespace Application.Features.Genders.Queries.GetList;

public class GetListGenderListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}