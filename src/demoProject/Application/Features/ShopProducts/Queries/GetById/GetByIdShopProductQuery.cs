using Application.Features.ShopProducts.Constants;
using Application.Features.ShopProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ShopProducts.Constants.ShopProductsOperationClaims;

namespace Application.Features.ShopProducts.Queries.GetById;

public class GetByIdShopProductQuery : IRequest<GetByIdShopProductResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShopProductQueryHandler : IRequestHandler<GetByIdShopProductQuery, GetByIdShopProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopProductRepository _shopProductRepository;
        private readonly ShopProductBusinessRules _shopProductBusinessRules;

        public GetByIdShopProductQueryHandler(IMapper mapper, IShopProductRepository shopProductRepository, ShopProductBusinessRules shopProductBusinessRules)
        {
            _mapper = mapper;
            _shopProductRepository = shopProductRepository;
            _shopProductBusinessRules = shopProductBusinessRules;
        }

        public async Task<GetByIdShopProductResponse> Handle(GetByIdShopProductQuery request, CancellationToken cancellationToken)
        {
            ShopProduct? shopProduct = await _shopProductRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _shopProductBusinessRules.ShopProductShouldExistWhenSelected(shopProduct);

            GetByIdShopProductResponse response = _mapper.Map<GetByIdShopProductResponse>(shopProduct);
            return response;
        }
    }
}