using Core.Application.Responses;

namespace Application.Features.TermConditions.Commands.Delete;

public class DeletedTermConditionResponse : IResponse
{
    public int Id { get; set; }
}