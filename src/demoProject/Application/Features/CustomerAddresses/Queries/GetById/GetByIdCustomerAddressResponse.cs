using Core.Application.Responses;

namespace Application.Features.CustomerAddresses.Queries.GetById;

public class GetByIdCustomerAddressResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }
}