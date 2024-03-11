using Core.Application.Responses;

namespace Application.Features.SubCategories.Commands.Update;

public class UpdatedSubCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public bool IsVerified { get; set; }
}