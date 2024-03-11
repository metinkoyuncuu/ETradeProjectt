using Core.Application.Responses;

namespace Application.Features.ProductFeatures.Commands.Update;

public class UpdatedProductFeatureResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Header { get; set; }
}