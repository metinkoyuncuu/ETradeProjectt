using Application.Features.Coupons.Constants;
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

namespace Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommand : IRequest<DeletedCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CouponsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCoupons";

    public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand, DeletedCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;
        private readonly CouponBusinessRules _couponBusinessRules;

        public DeleteCouponCommandHandler(IMapper mapper, ICouponRepository couponRepository,
                                         CouponBusinessRules couponBusinessRules)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
            _couponBusinessRules = couponBusinessRules;
        }

        public async Task<DeletedCouponResponse> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon? coupon = await _couponRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _couponBusinessRules.CouponShouldExistWhenSelected(coupon);

            await _couponRepository.DeleteAsync(coupon!);

            DeletedCouponResponse response = _mapper.Map<DeletedCouponResponse>(coupon);
            return response;
        }
    }
}