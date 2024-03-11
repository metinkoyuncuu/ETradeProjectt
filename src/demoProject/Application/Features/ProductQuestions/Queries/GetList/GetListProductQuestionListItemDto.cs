using Core.Application.Dtos;

namespace Application.Features.ProductQuestions.Queries.GetList;

public class GetListProductQuestionListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}