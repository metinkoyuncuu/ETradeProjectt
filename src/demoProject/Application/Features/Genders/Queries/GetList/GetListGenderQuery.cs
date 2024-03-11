using Application.Features.Genders.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Genders.Constants.GendersOperationClaims;

namespace Application.Features.Genders.Queries.GetList;

public class GetListGenderQuery : IRequest<GetListResponse<GetListGenderListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListGenders({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetGenders";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListGenderQueryHandler : IRequestHandler<GetListGenderQuery, GetListResponse<GetListGenderListItemDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GetListGenderQueryHandler(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenderListItemDto>> Handle(GetListGenderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Gender> genders = await _genderRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenderListItemDto> response = _mapper.Map<GetListResponse<GetListGenderListItemDto>>(genders);
            return response;
        }
    }
}