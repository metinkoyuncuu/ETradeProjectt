using Application.Features.TermConditions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.TermConditions.Constants.TermConditionsOperationClaims;

namespace Application.Features.TermConditions.Queries.GetList;

public class GetListTermConditionQuery : IRequest<GetListResponse<GetListTermConditionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListTermConditions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetTermConditions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTermConditionQueryHandler : IRequestHandler<GetListTermConditionQuery, GetListResponse<GetListTermConditionListItemDto>>
    {
        private readonly ITermConditionRepository _termConditionRepository;
        private readonly IMapper _mapper;

        public GetListTermConditionQueryHandler(ITermConditionRepository termConditionRepository, IMapper mapper)
        {
            _termConditionRepository = termConditionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTermConditionListItemDto>> Handle(GetListTermConditionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TermCondition> termConditions = await _termConditionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTermConditionListItemDto> response = _mapper.Map<GetListResponse<GetListTermConditionListItemDto>>(termConditions);
            return response;
        }
    }
}