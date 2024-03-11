using Application.Features.ShopCoupons.Constants;
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

namespace Application.Features.ShopCoupons.Commands.Delete;

public class DeleteShopCouponCommand : IRequest<DeletedShopCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopCouponsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopCoupons";

    public class DeleteShopCouponCommandHandler : IRequestHandler<DeleteShopCouponCommand, DeletedShopCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopCouponRepository _shopCouponRepository;
        private readonly ShopCouponBusinessRules _shopCouponBusinessRules;

        public DeleteShopCouponCommandHandler(IMapper mapper, IShopCouponRepository shopCouponRepository,
                                         ShopCouponBusinessRules shopCouponBusinessRules)
        {
            _mapper = mapper;
            _shopCouponRepository = shopCouponRepository;
            _shopCouponBusinessRules = shopCouponBusinessRules;
        }

        public async Task<DeletedShopCouponResponse> Handle(DeleteShopCouponCommand request, CancellationToken cancellationToken)
        {
            ShopCoupon? shopCoupon = await _shopCouponRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _shopCouponBusinessRules.ShopCouponShouldExistWhenSelected(shopCoupon);

            await _shopCouponRepository.DeleteAsync(shopCoupon!);

            DeletedShopCouponResponse response = _mapper.Map<DeletedShopCouponResponse>(shopCoupon);
            return response;
        }
    }
}