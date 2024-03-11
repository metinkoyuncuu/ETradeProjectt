using Core.Application.Dtos;

namespace Application.Features.Cashbacks.Queries.GetList;

public class GetListCashbackListItemDto : IDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }
}