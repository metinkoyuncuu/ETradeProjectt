using Core.Application.Responses;

namespace Application.Features.ProductImages.Queries.GetById;

public class GetByIdProductImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
}