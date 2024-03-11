using Core.Application.Dtos;

namespace Application.Features.TermConditions.Queries.GetList;

public class GetListTermConditionListItemDto : IDto
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
}