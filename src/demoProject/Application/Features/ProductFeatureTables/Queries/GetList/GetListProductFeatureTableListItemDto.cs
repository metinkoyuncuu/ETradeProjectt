using Core.Application.Dtos;

namespace Application.Features.ProductFeatureTables.Queries.GetList;

public class GetListProductFeatureTableListItemDto : IDto
{
    public int Id { get; set; }
    public string Column { get; set; }
    public string Description { get; set; }
    public int ProductFeatureId { get; set; }
}