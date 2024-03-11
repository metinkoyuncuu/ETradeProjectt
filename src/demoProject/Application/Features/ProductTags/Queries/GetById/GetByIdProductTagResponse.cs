using Core.Application.Responses;

namespace Application.Features.ProductTags.Queries.GetById;

public class GetByIdProductTagResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TagId { get; set; }
}