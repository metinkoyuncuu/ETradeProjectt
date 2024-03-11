using Application.Features.Sizes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Queries.GetList;

public class GetListSizeQuery : IRequest<GetListResponse<GetListSizeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSizes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSizes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSizeQueryHandler : IRequestHandler<GetListSizeQuery, GetListResponse<GetListSizeListItemDto>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public GetListSizeQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSizeListItemDto>> Handle(GetListSizeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Size> sizes = await _sizeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSizeListItemDto> response = _mapper.Map<GetListResponse<GetListSizeListItemDto>>(sizes);
            return response;
        }
    }
}