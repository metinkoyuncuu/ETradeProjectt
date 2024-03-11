using Core.Application.Responses;

namespace Application.Features.ProductQuestions.Queries.GetById;

public class GetByIdProductQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}