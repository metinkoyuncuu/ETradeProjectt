using Core.Application.Responses;

namespace Application.Features.Genders.Commands.Update;

public class UpdatedGenderResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}