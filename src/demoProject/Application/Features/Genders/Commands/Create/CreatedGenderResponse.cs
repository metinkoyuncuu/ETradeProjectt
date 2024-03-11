using Core.Application.Responses;

namespace Application.Features.Genders.Commands.Create;

public class CreatedGenderResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}