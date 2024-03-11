using Core.Application.Dtos;

namespace Application.Features.ProductFeatures.Queries.GetList;

public class GetListProductFeatureListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Header { get; set; }
}