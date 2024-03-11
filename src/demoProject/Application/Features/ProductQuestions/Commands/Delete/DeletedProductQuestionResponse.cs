using Core.Application.Responses;

namespace Application.Features.ProductQuestions.Commands.Delete;

public class DeletedProductQuestionResponse : IResponse
{
    public int Id { get; set; }
}