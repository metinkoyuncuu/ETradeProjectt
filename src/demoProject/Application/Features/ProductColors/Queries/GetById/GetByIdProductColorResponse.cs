using Core.Application.Responses;

namespace Application.Features.ProductColors.Queries.GetById;

public class GetByIdProductColorResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int ImageId { get; set; }
}