using Application.Features.Coupons.Constants;
using Application.Features.Coupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Coupons.Constants.CouponsOperationClaims;

namespace Application.Features.Coupons.Queries.GetById;

public class GetByIdCouponQuery : IRequest<GetByIdCouponResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCouponQueryHandler : IRequestHandler<GetByIdCouponQuery, GetByIdCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;
        private readonly CouponBusinessRules _couponBusinessRules;

        public GetByIdCouponQueryHandler(IMapper mapper, ICouponRepository couponRepository, CouponBusinessRules couponBusinessRules)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
            _couponBusinessRules = couponBusinessRules;
        }

        public async Task<GetByIdCouponResponse> Handle(GetByIdCouponQuery request, CancellationToken cancellationToken)
        {
            Coupon? coupon = await _couponRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _couponBusinessRules.CouponShouldExistWhenSelected(coupon);

            GetByIdCouponResponse response = _mapper.Map<GetByIdCouponResponse>(coupon);
            return response;
        }
    }
}