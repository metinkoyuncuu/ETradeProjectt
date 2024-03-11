using Core.Application.Responses;

namespace Application.Features.Cashbacks.Queries.GetById;

public class GetByIdCashbackResponse : IResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }
}