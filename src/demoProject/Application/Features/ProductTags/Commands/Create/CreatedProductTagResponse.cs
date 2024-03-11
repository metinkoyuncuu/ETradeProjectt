using Core.Application.Responses;

namespace Application.Features.ProductTags.Commands.Create;

public class CreatedProductTagResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TagId { get; set; }
}