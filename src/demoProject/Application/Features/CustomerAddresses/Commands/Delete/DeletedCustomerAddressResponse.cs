using Core.Application.Responses;

namespace Application.Features.CustomerAddresses.Commands.Delete;

public class DeletedCustomerAddressResponse : IResponse
{
    public int Id { get; set; }
}