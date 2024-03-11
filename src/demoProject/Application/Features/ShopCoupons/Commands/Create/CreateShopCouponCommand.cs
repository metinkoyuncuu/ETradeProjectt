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

namespace Application.Features.ShopCoupons.Commands.Create;

public class CreateShopCouponCommand : IRequest<CreatedShopCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CouponId { get; set; }
    public int ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopCouponsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopCoupons";

    public class CreateShopCouponCommandHandler : IRequestHandler<CreateShopCouponCommand, CreatedShopCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopCouponRepository _shopCouponRepository;
        private readonly ShopCouponBusinessRules _shopCouponBusinessRules;

        public CreateShopCouponCommandHandler(IMapper mapper, IShopCouponRepository shopCouponRepository,
                                         ShopCouponBusinessRules shopCouponBusinessRules)
        {
            _mapper = mapper;
            _shopCouponRepository = shopCouponRepository;
            _shopCouponBusinessRules = shopCouponBusinessRules;
        }

        public async Task<CreatedShopCouponResponse> Handle(CreateShopCouponCommand request, CancellationToken cancellationToken)
        {
            ShopCoupon shopCoupon = _mapper.Map<ShopCoupon>(request);

            await _shopCouponRepository.AddAsync(shopCoupon);

            CreatedShopCouponResponse response = _mapper.Map<CreatedShopCouponResponse>(shopCoupon);
            return response;
        }
    }
}