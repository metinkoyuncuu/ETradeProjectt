using Core.Application.Responses;

namespace Application.Features.Sizes.Queries.GetById;

public class GetByIdSizeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}