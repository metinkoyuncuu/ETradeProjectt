using Application.Features.ShopCoupons.Constants;
using Application.Features.ShopCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ShopCoupons.Constants.ShopCouponsOperationClaims;

namespace Application.Features.ShopCoupons.Commands.Update;

public class UpdateShopCouponCommand : IRequest<UpdatedShopCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public int ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopCouponsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopCoupons";

    public class UpdateShopCouponCommandHandler : IRequestHandler<UpdateShopCouponCommand, UpdatedShopCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopCouponRepository _shopCouponRepository;
        private readonly ShopCouponBusinessRules _shopCouponBusinessRules;

        public UpdateShopCouponCommandHandler(IMapper mapper, IShopCouponRepository shopCouponRepository,
                                         ShopCouponBusinessRules shopCouponBusinessRules)
        {
            _mapper = mapper;
            _shopCouponRepository = shopCouponRepository;
            _shopCouponBusinessRules = shopCouponBusinessRules;
        }

        public async Task<UpdatedShopCouponResponse> Handle(UpdateShopCouponCommand request, CancellationToken cancellationToken)
        {
            ShopCoupon? shopCoupon = await _shopCouponRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _shopCouponBusinessRules.ShopCouponShouldExistWhenSelected(shopCoupon);
            shopCoupon = _mapper.Map(request, shopCoupon);

            await _shopCouponRepository.UpdateAsync(shopCoupon!);

            UpdatedShopCouponResponse response = _mapper.Map<UpdatedShopCouponResponse>(shopCoupon);
            return response;
        }
    }
}