using Core.Application.Responses;

namespace Application.Features.ProductFeatures.Queries.GetById;

public class GetByIdProductFeatureResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Header { get; set; }
}