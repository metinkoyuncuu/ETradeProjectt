using Core.Application.Responses;

namespace Application.Features.CustomerCompares.Queries.GetById;

public class GetByIdCustomerCompareResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}