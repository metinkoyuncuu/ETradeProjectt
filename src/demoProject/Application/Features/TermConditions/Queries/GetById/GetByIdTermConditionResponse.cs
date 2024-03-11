using Core.Application.Responses;

namespace Application.Features.TermConditions.Queries.GetById;

public class GetByIdTermConditionResponse : IResponse
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
}