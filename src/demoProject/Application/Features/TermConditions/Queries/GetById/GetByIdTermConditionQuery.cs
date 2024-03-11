using Application.Features.TermConditions.Constants;
using Application.Features.TermConditions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TermConditions.Constants.TermConditionsOperationClaims;

namespace Application.Features.TermConditions.Queries.GetById;

public class GetByIdTermConditionQuery : IRequest<GetByIdTermConditionResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdTermConditionQueryHandler : IRequestHandler<GetByIdTermConditionQuery, GetByIdTermConditionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermConditionRepository _termConditionRepository;
        private readonly TermConditionBusinessRules _termConditionBusinessRules;

        public GetByIdTermConditionQueryHandler(IMapper mapper, ITermConditionRepository termConditionRepository, TermConditionBusinessRules termConditionBusinessRules)
        {
            _mapper = mapper;
            _termConditionRepository = termConditionRepository;
            _termConditionBusinessRules = termConditionBusinessRules;
        }

        public async Task<GetByIdTermConditionResponse> Handle(GetByIdTermConditionQuery request, CancellationToken cancellationToken)
        {
            TermCondition? termCondition = await _termConditionRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _termConditionBusinessRules.TermConditionShouldExistWhenSelected(termCondition);

            GetByIdTermConditionResponse response = _mapper.Map<GetByIdTermConditionResponse>(termCondition);
            return response;
        }
    }
}