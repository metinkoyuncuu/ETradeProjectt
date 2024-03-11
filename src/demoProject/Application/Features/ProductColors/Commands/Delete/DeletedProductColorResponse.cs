using Core.Application.Responses;

namespace Application.Features.ProductColors.Commands.Delete;

public class DeletedProductColorResponse : IResponse
{
    public int Id { get; set; }
}