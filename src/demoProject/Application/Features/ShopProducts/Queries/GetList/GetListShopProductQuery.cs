using Application.Features.ShopProducts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ShopProducts.Constants.ShopProductsOperationClaims;

namespace Application.Features.ShopProducts.Queries.GetList;

public class GetListShopProductQuery : IRequest<GetListResponse<GetListShopProductListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShopProducts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShopProducts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShopProductQueryHandler : IRequestHandler<GetListShopProductQuery, GetListResponse<GetListShopProductListItemDto>>
    {
        private readonly IShopProductRepository _shopProductRepository;
        private readonly IMapper _mapper;

        public GetListShopProductQueryHandler(IShopProductRepository shopProductRepository, IMapper mapper)
        {
            _shopProductRepository = shopProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShopProductListItemDto>> Handle(GetListShopProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ShopProduct> shopProducts = await _shopProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShopProductListItemDto> response = _mapper.Map<GetListResponse<GetListShopProductListItemDto>>(shopProducts);
            return response;
        }
    }
}