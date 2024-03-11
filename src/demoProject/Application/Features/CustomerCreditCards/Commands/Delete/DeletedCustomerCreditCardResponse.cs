using Core.Application.Responses;

namespace Application.Features.CustomerCreditCards.Commands.Delete;

public class DeletedCustomerCreditCardResponse : IResponse
{
    public int Id { get; set; }
}