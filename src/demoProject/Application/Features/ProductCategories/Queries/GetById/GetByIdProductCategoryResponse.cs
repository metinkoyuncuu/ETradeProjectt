using Core.Application.Responses;

namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}