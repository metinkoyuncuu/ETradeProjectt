using Core.Application.Responses;

namespace Application.Features.Sellers.Queries.GetById;

public class GetByIdSellerResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string PersonalAddress { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string IdentityNumber { get; set; }
    public int ImageId { get; set; }
    public bool IsVerified { get; set; }
    public DateTime BirthDate { get; set; }
    public int GenderId { get; set; }
}