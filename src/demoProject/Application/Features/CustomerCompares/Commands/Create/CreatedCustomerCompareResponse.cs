using Core.Application.Responses;

namespace Application.Features.CustomerCompares.Commands.Create;

public class CreatedCustomerCompareResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}