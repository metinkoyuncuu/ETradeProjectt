using Core.Application.Responses;

namespace Application.Features.Cashbacks.Commands.Delete;

public class DeletedCashbackResponse : IResponse
{
    public int Id { get; set; }
}