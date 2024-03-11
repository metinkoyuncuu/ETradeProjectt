using Core.Application.Responses;

namespace Application.Features.ProductQuestions.Commands.Update;

public class UpdatedProductQuestionResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}