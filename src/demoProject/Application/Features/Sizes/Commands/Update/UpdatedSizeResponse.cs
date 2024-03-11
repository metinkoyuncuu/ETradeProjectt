using Core.Application.Responses;

namespace Application.Features.Sizes.Commands.Update;

public class UpdatedSizeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}