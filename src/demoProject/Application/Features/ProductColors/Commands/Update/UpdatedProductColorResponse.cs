using Core.Application.Responses;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdatedProductColorResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int ImageId { get; set; }
}