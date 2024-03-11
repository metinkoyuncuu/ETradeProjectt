using Application.Features.Genders.Constants;
using Application.Features.Genders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Genders.Constants.GendersOperationClaims;

namespace Application.Features.Genders.Commands.Create;

public class CreateGenderCommand : IRequest<CreatedGenderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, GendersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGenders";

    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, CreatedGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public CreateGenderCommandHandler(IMapper mapper, IGenderRepository genderRepository,
                                         GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<CreatedGenderResponse> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            Gender gender = _mapper.Map<Gender>(request);

            await _genderRepository.AddAsync(gender);

            CreatedGenderResponse response = _mapper.Map<CreatedGenderResponse>(gender);
            return response;
        }
    }
}