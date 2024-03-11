using Application.Features.Shops.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Shops.Constants.ShopsOperationClaims;

namespace Application.Features.Shops.Queries.GetList;

public class GetListShopQuery : IRequest<GetListResponse<GetListShopListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShops({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShops";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShopQueryHandler : IRequestHandler<GetListShopQuery, GetListResponse<GetListShopListItemDto>>
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public GetListShopQueryHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShopListItemDto>> Handle(GetListShopQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Shop> shops = await _shopRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShopListItemDto> response = _mapper.Map<GetListResponse<GetListShopListItemDto>>(shops);
            return response;
        }
    }
}