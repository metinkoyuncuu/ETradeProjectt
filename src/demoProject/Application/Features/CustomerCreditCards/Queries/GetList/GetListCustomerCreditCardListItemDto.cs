using Core.Application.Dtos;

namespace Application.Features.CustomerCreditCards.Queries.GetList;

public class GetListCustomerCreditCardListItemDto : IDto
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