using Application.Features.Genders.Constants;
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

namespace Application.Features.Genders.Commands.Delete;

public class DeleteGenderCommand : IRequest<DeletedGenderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, GendersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetGenders";

    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, DeletedGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public DeleteGenderCommandHandler(IMapper mapper, IGenderRepository genderRepository,
                                         GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<DeletedGenderResponse> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            Gender? gender = await _genderRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genderBusinessRules.GenderShouldExistWhenSelected(gender);

            await _genderRepository.DeleteAsync(gender!);

            DeletedGenderResponse response = _mapper.Map<DeletedGenderResponse>(gender);
            return response;
        }
    }
}