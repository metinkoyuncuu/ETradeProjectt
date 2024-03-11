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

namespace Application.Features.Coupons.Commands.Update;

public class UpdateCouponCommand : IRequest<UpdatedCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
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

    public string[] Roles => new[] { Admin, Write, CouponsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCoupons";

    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand, UpdatedCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;
        private readonly CouponBusinessRules _couponBusinessRules;

        public UpdateCouponCommandHandler(IMapper mapper, ICouponRepository couponRepository,
                                         CouponBusinessRules couponBusinessRules)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
            _couponBusinessRules = couponBusinessRules;
        }

        public async Task<UpdatedCouponResponse> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon? coupon = await _couponRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _couponBusinessRules.CouponShouldExistWhenSelected(coupon);
            coupon = _mapper.Map(request, coupon);

            await _couponRepository.UpdateAsync(coupon!);

            UpdatedCouponResponse response = _mapper.Map<UpdatedCouponResponse>(coupon);
            return response;
        }
    }
}