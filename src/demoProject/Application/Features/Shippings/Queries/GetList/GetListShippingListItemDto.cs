using Core.Application.Dtos;

namespace Application.Features.Shippings.Queries.GetList;

public class GetListShippingListItemDto : IDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
}