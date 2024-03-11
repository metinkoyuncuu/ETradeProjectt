using Core.Application.Responses;

namespace Application.Features.ProductCategories.Commands.Delete;

public class DeletedProductCategoryResponse : IResponse
{
    public int Id { get; set; }
}