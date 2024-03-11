using Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Create;

public class CreatedProductImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ImageId { get; set; }
}