using Core.Application.Responses;

namespace Application.Features.Sizes.Commands.Create;

public class CreatedSizeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}