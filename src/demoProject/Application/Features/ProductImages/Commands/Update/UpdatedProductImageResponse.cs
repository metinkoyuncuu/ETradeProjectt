using Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Update;

public class UpdatedProductImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
}