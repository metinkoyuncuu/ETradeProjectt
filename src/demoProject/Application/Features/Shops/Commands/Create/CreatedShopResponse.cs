using Core.Application.Responses;

namespace Application.Features.Shops.Commands.Create;

public class CreatedShopResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? TaxNumber { get; set; }
    public string AccessKey { get; set; }
    public string Address { get; set; }
    public bool IsVerified { get; set; }
    public float Balance { get; set; }
}