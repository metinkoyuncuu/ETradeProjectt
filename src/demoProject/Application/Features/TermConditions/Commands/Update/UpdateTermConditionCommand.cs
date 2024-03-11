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

namespace Application.Features.TermConditions.Commands.Update;

public class UpdateTermConditionCommand : IRequest<UpdatedTermConditionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }

    public string[] Roles => new[] { Admin, Write, TermConditionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTermConditions";

    public class UpdateTermConditionCommandHandler : IRequestHandler<UpdateTermConditionCommand, UpdatedTermConditionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermConditionRepository _termConditionRepository;
        private readonly TermConditionBusinessRules _termConditionBusinessRules;

        public UpdateTermConditionCommandHandler(IMapper mapper, ITermConditionRepository termConditionRepository,
                                         TermConditionBusinessRules termConditionBusinessRules)
        {
            _mapper = mapper;
            _termConditionRepository = termConditionRepository;
            _termConditionBusinessRules = termConditionBusinessRules;
        }

        public async Task<UpdatedTermConditionResponse> Handle(UpdateTermConditionCommand request, CancellationToken cancellationToken)
        {
            TermCondition? termCondition = await _termConditionRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _termConditionBusinessRules.TermConditionShouldExistWhenSelected(termCondition);
            termCondition = _mapper.Map(request, termCondition);

            await _termConditionRepository.UpdateAsync(termCondition!);

            UpdatedTermConditionResponse response = _mapper.Map<UpdatedTermConditionResponse>(termCondition);
            return response;
        }
    }
}