using Core.Application.Responses;

namespace Application.Features.ProductFeatureTables.Commands.Delete;

public class DeletedProductFeatureTableResponse : IResponse
{
    public int Id { get; set; }
}