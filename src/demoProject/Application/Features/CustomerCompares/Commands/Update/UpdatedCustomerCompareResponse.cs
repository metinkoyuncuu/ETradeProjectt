using Core.Application.Responses;

namespace Application.Features.CustomerCompares.Commands.Update;

public class UpdatedCustomerCompareResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}