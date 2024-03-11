using Application.Features.ShopCoupons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ShopCoupons.Constants.ShopCouponsOperationClaims;

namespace Application.Features.ShopCoupons.Queries.GetList;

public class GetListShopCouponQuery : IRequest<GetListResponse<GetListShopCouponListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShopCoupons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShopCoupons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShopCouponQueryHandler : IRequestHandler<GetListShopCouponQuery, GetListResponse<GetListShopCouponListItemDto>>
    {
        private readonly IShopCouponRepository _shopCouponRepository;
        private readonly IMapper _mapper;

        public GetListShopCouponQueryHandler(IShopCouponRepository shopCouponRepository, IMapper mapper)
        {
            _shopCouponRepository = shopCouponRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShopCouponListItemDto>> Handle(GetListShopCouponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ShopCoupon> shopCoupons = await _shopCouponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShopCouponListItemDto> response = _mapper.Map<GetListResponse<GetListShopCouponListItemDto>>(shopCoupons);
            return response;
        }
    }
}