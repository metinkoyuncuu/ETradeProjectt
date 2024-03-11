using Application.Features.ShopProducts.Constants;
using Application.Features.ShopProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ShopProducts.Constants.ShopProductsOperationClaims;

namespace Application.Features.ShopProducts.Commands.Update;

public class UpdateShopProductCommand : IRequest<UpdatedShopProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopProductsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopProducts";

    public class UpdateShopProductCommandHandler : IRequestHandler<UpdateShopProductCommand, UpdatedShopProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopProductRepository _shopProductRepository;
        private readonly ShopProductBusinessRules _shopProductBusinessRules;

        public UpdateShopProductCommandHandler(IMapper mapper, IShopProductRepository shopProductRepository,
                                         ShopProductBusinessRules shopProductBusinessRules)
        {
            _mapper = mapper;
            _shopProductRepository = shopProductRepository;
            _shopProductBusinessRules = shopProductBusinessRules;
        }

        public async Task<UpdatedShopProductResponse> Handle(UpdateShopProductCommand request, CancellationToken cancellationToken)
        {
            ShopProduct? shopProduct = await _shopProductRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _shopProductBusinessRules.ShopProductShouldExistWhenSelected(shopProduct);
            shopProduct = _mapper.Map(request, shopProduct);

            await _shopProductRepository.UpdateAsync(shopProduct!);

            UpdatedShopProductResponse response = _mapper.Map<UpdatedShopProductResponse>(shopProduct);
            return response;
        }
    }
}