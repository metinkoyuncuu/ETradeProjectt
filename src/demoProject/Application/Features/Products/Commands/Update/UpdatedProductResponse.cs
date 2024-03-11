using Core.Application.Responses;

namespace Application.Features.Products.Commands.Update;

public class UpdatedProductResponse : IResponse
{
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public bool IsDiscounted { get; set; }
    public string DiscountType { get; set; }
    public string DiscountValue { get; set; }
    public string? Weight { get; set; }
    public int QuantityInStock { get; set; }
    public int SubCategoryId { get; set; }
    public float ShipPrice { get; set; }
    public int BrandId { get; set; }
}