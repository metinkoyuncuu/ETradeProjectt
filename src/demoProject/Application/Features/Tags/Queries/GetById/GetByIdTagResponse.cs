using Core.Application.Responses;

namespace Application.Features.Tags.Queries.GetById;

public class GetByIdTagResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}