using Application.Features.Coupons.Constants;
using Application.Features.Coupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Coupons.Constants.CouponsOperationClaims;

namespace Application.Features.Coupons.Commands.Create;

public class CreateCouponCommand : IRequest<CreatedCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string DiscountType { get; set; }
    public int DiscountValue { get; set; }
    public int MinimumPurchase { get; set; }
    public bool ApplicableToAllShops { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UsageLimit { get; set; }
    public bool IsVerified { get; set; }

    public string[] Roles => new[] { Admin, Write, CouponsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCoupons";

    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, CreatedCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;
        private readonly CouponBusinessRules _couponBusinessRules;

        public CreateCouponCommandHandler(IMapper mapper, ICouponRepository couponRepository,
                                         CouponBusinessRules couponBusinessRules)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
            _couponBusinessRules = couponBusinessRules;
        }

        public async Task<CreatedCouponResponse> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon coupon = _mapper.Map<Coupon>(request);

            await _couponRepository.AddAsync(coupon);

            CreatedCouponResponse response = _mapper.Map<CreatedCouponResponse>(coupon);
            return response;
        }
    }
}