using Core.Application.Responses;

namespace Application.Features.CustomerCreditCards.Commands.Create;

public class CreatedCustomerCreditCardResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CardType { get; set; }
    public string HolderName { get; set; }
    public string ExpireMonth { get; set; }
    public string ExpireYear { get; set; }
    public string CVV { get; set; }
    public string CardNumber { get; set; }
}