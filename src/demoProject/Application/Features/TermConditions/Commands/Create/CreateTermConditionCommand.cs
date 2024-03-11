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

namespace Application.Features.TermConditions.Commands.Create;

public class CreateTermConditionCommand : IRequest<CreatedTermConditionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Header { get; set; }
    public string Text { get; set; }

    public string[] Roles => new[] { Admin, Write, TermConditionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTermConditions";

    public class CreateTermConditionCommandHandler : IRequestHandler<CreateTermConditionCommand, CreatedTermConditionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermConditionRepository _termConditionRepository;
        private readonly TermConditionBusinessRules _termConditionBusinessRules;

        public CreateTermConditionCommandHandler(IMapper mapper, ITermConditionRepository termConditionRepository,
                                         TermConditionBusinessRules termConditionBusinessRules)
        {
            _mapper = mapper;
            _termConditionRepository = termConditionRepository;
            _termConditionBusinessRules = termConditionBusinessRules;
        }

        public async Task<CreatedTermConditionResponse> Handle(CreateTermConditionCommand request, CancellationToken cancellationToken)
        {
            TermCondition termCondition = _mapper.Map<TermCondition>(request);

            await _termConditionRepository.AddAsync(termCondition);

            CreatedTermConditionResponse response = _mapper.Map<CreatedTermConditionResponse>(termCondition);
            return response;
        }
    }
}