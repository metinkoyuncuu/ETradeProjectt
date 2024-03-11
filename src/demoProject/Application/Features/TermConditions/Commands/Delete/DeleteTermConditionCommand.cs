using Application.Features.TermConditions.Constants;
using Application.Features.TermConditions.Constants;
using Application.Features.TermConditions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TermConditions.Constants.TermConditionsOperationClaims;

namespace Application.Features.TermConditions.Commands.Delete;

public class DeleteTermConditionCommand : IRequest<DeletedTermConditionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, TermConditionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTermConditions";

    public class DeleteTermConditionCommandHandler : IRequestHandler<DeleteTermConditionCommand, DeletedTermConditionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermConditionRepository _termConditionRepository;
        private readonly TermConditionBusinessRules _termConditionBusinessRules;

        public DeleteTermConditionCommandHandler(IMapper mapper, ITermConditionRepository termConditionRepository,
                                         TermConditionBusinessRules termConditionBusinessRules)
        {
            _mapper = mapper;
            _termConditionRepository = termConditionRepository;
            _termConditionBusinessRules = termConditionBusinessRules;
        }

        public async Task<DeletedTermConditionResponse> Handle(DeleteTermConditionCommand request, CancellationToken cancellationToken)
        {
            TermCondition? termCondition = await _termConditionRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _termConditionBusinessRules.TermConditionShouldExistWhenSelected(termCondition);

            await _termConditionRepository.DeleteAsync(termCondition!);

            DeletedTermConditionResponse response = _mapper.Map<DeletedTermConditionResponse>(termCondition);
            return response;
        }
    }
}