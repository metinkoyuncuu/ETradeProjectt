using Core.Application.Responses;

namespace Application.Features.Genders.Commands.Delete;

public class DeletedGenderResponse : IResponse
{
    public int Id { get; set; }
}