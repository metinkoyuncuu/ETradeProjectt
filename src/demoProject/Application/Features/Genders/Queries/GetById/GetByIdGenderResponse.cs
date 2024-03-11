using Core.Application.Responses;

namespace Application.Features.Genders.Queries.GetById;

public class GetByIdGenderResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}