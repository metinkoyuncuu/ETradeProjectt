using Core.Application.Responses;

namespace Application.Features.Bills.Commands.Delete;

public class DeletedBillResponse : IResponse
{
    public int Id { get; set; }
}