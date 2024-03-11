using Core.Application.Dtos;

namespace Application.Features.ProductTags.Queries.GetList;

public class GetListProductTagListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TagId { get; set; }
}