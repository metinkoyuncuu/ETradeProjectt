using Core.Application.Responses;

namespace Application.Features.ProductFeatures.Commands.Create;

public class CreatedProductFeatureResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Header { get; set; }
}