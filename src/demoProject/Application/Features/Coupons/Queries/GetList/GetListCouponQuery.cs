using Application.Features.Coupons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Coupons.Constants.CouponsOperationClaims;

namespace Application.Features.Coupons.Queries.GetList;

public class GetListCouponQuery : IRequest<GetListResponse<GetListCouponListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCoupons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCoupons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCouponQueryHandler : IRequestHandler<GetListCouponQuery, GetListResponse<GetListCouponListItemDto>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public GetListCouponQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCouponListItemDto>> Handle(GetListCouponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Coupon> coupons = await _couponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCouponListItemDto> response = _mapper.Map<GetListResponse<GetListCouponListItemDto>>(coupons);
            return response;
        }
    }
}