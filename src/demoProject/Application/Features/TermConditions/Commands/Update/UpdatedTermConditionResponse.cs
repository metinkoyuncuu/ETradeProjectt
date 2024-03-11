using Core.Application.Responses;

namespace Application.Features.TermConditions.Commands.Update;

public class UpdatedTermConditionResponse : IResponse
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
}