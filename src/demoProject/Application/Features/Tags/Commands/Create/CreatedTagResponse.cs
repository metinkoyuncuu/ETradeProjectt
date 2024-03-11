using Core.Application.Responses;

namespace Application.Features.Tags.Commands.Create;

public class CreatedTagResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}