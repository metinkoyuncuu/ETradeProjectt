using Application.Features.CustomerCoupons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCoupons.Constants.CustomerCouponsOperationClaims;

namespace Application.Features.CustomerCoupons.Queries.GetList;

public class GetListCustomerCouponQuery : IRequest<GetListResponse<GetListCustomerCouponListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerCoupons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerCoupons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerCouponQueryHandler : IRequestHandler<GetListCustomerCouponQuery, GetListResponse<GetListCustomerCouponListItemDto>>
    {
        private readonly ICustomerCouponRepository _customerCouponRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCouponQueryHandler(ICustomerCouponRepository customerCouponRepository, IMapper mapper)
        {
            _customerCouponRepository = customerCouponRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCouponListItemDto>> Handle(GetListCustomerCouponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCoupon> customerCoupons = await _customerCouponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCouponListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCouponListItemDto>>(customerCoupons);
            return response;
        }
    }
}