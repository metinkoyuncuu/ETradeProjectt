using Core.Application.Responses;

namespace Application.Features.Brands.Commands.Update;

public class UpdatedBrandResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }
}