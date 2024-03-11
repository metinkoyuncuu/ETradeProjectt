using Core.Application.Responses;

namespace Application.Features.Customers.Commands.Update;

public class UpdatedCustomerResponse : IResponse
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public float Balance { get; set; }
    public DateTime BirthDate { get; set; }
    public int ImageId { get; set; }
    public int GenderId { get; set; }
    public int UserId { get; set; }
}