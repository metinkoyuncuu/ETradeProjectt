using Core.Application.Responses;

namespace Application.Features.CustomerCompares.Commands.Delete;

public class DeletedCustomerCompareResponse : IResponse
{
    public int Id { get; set; }
}