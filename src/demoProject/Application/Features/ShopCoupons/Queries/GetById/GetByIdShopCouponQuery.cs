using Application.Features.ShopCoupons.Constants;
using Application.Features.ShopCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ShopCoupons.Constants.ShopCouponsOperationClaims;

namespace Application.Features.ShopCoupons.Queries.GetById;

public class GetByIdShopCouponQuery : IRequest<GetByIdShopCouponResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShopCouponQueryHandler : IRequestHandler<GetByIdShopCouponQuery, GetByIdShopCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopCouponRepository _shopCouponRepository;
        private readonly ShopCouponBusinessRules _shopCouponBusinessRules;

        public GetByIdShopCouponQueryHandler(IMapper mapper, IShopCouponRepository shopCouponRepository, ShopCouponBusinessRules shopCouponBusinessRules)
        {
            _mapper = mapper;
            _shopCouponRepository = shopCouponRepository;
            _shopCouponBusinessRules = shopCouponBusinessRules;
        }

        public async Task<GetByIdShopCouponResponse> Handle(GetByIdShopCouponQuery request, CancellationToken cancellationToken)
        {
            ShopCoupon? shopCoupon = await _shopCouponRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _shopCouponBusinessRules.ShopCouponShouldExistWhenSelected(shopCoupon);

            GetByIdShopCouponResponse response = _mapper.Map<GetByIdShopCouponResponse>(shopCoupon);
            return response;
        }
    }
}