using Core.Application.Responses;

namespace Application.Features.ProductFeatureTables.Commands.Update;

public class UpdatedProductFeatureTableResponse : IResponse
{
    public int Id { get; set; }
    public string Column { get; set; }
    public string Description { get; set; }
    public int ProductFeatureId { get; set; }
}