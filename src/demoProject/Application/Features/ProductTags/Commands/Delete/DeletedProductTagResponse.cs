using Core.Application.Responses;

namespace Application.Features.ProductTags.Commands.Delete;

public class DeletedProductTagResponse : IResponse
{
    public int Id { get; set; }
}