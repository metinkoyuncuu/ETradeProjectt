using Core.Application.Responses;

namespace Application.Features.Tags.Commands.Update;

public class UpdatedTagResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}