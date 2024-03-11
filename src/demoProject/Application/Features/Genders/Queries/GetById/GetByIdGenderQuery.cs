using Application.Features.Genders.Constants;
using Application.Features.Genders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Genders.Constants.GendersOperationClaims;

namespace Application.Features.Genders.Queries.GetById;

public class GetByIdGenderQuery : IRequest<GetByIdGenderResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdGenderQueryHandler : IRequestHandler<GetByIdGenderQuery, GetByIdGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public GetByIdGenderQueryHandler(IMapper mapper, IGenderRepository genderRepository, GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<GetByIdGenderResponse> Handle(GetByIdGenderQuery request, CancellationToken cancellationToken)
        {
            Gender? gender = await _genderRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genderBusinessRules.GenderShouldExistWhenSelected(gender);

            GetByIdGenderResponse response = _mapper.Map<GetByIdGenderResponse>(gender);
            return response;
        }
    }
}