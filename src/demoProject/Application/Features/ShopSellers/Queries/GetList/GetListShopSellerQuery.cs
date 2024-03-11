using Application.Features.ShopSellers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ShopSellers.Constants.ShopSellersOperationClaims;

namespace Application.Features.ShopSellers.Queries.GetList;

public class GetListShopSellerQuery : IRequest<GetListResponse<GetListShopSellerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShopSellers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShopSellers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShopSellerQueryHandler : IRequestHandler<GetListShopSellerQuery, GetListResponse<GetListShopSellerListItemDto>>
    {
        private readonly IShopSellerRepository _shopSellerRepository;
        private readonly IMapper _mapper;

        public GetListShopSellerQueryHandler(IShopSellerRepository shopSellerRepository, IMapper mapper)
        {
            _shopSellerRepository = shopSellerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShopSellerListItemDto>> Handle(GetListShopSellerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ShopSeller> shopSellers = await _shopSellerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShopSellerListItemDto> response = _mapper.Map<GetListResponse<GetListShopSellerListItemDto>>(shopSellers);
            return response;
        }
    }
}