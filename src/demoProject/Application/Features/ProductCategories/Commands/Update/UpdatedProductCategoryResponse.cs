using Core.Application.Responses;

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdatedProductCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}