using Core.Application.Responses;

namespace Application.Features.Cashbacks.Commands.Update;

public class UpdatedCashbackResponse : IResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }
}