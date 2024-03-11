using Core.Application.Responses;

namespace Application.Features.ProductFeatures.Commands.Delete;

public class DeletedProductFeatureResponse : IResponse
{
    public int Id { get; set; }
}