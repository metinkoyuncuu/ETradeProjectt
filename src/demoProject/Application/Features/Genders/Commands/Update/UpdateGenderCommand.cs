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

namespace Application.Features.Genders.Commands.Update;

public class UpdateGenderCommand : IRequest<UpdatedGenderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, GendersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGenders";

    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, UpdatedGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public UpdateGenderCommandHandler(IMapper mapper, IGenderRepository genderRepository,
                                         GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<UpdatedGenderResponse> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            Gender? gender = await _genderRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genderBusinessRules.GenderShouldExistWhenSelected(gender);
            gender = _mapper.Map(request, gender);

            await _genderRepository.UpdateAsync(gender!);

            UpdatedGenderResponse response = _mapper.Map<UpdatedGenderResponse>(gender);
            return response;
        }
    }
}