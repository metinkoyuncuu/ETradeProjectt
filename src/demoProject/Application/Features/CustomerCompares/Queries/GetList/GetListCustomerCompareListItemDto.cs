using Core.Application.Dtos;

namespace Application.Features.CustomerCompares.Queries.GetList;

public class GetListCustomerCompareListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}