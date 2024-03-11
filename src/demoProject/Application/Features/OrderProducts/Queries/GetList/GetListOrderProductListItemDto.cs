using Core.Application.Dtos;

namespace Application.Features.OrderProducts.Queries.GetList;

public class GetListOrderProductListItemDto : IDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }
}