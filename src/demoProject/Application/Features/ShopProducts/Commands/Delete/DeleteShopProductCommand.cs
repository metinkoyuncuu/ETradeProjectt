using Application.Features.ShopProducts.Constants;
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

namespace Application.Features.ShopProducts.Commands.Delete;

public class DeleteShopProductCommand : IRequest<DeletedShopProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopProductsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopProducts";

    public class DeleteShopProductCommandHandler : IRequestHandler<DeleteShopProductCommand, DeletedShopProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopProductRepository _shopProductRepository;
        private readonly ShopProductBusinessRules _shopProductBusinessRules;

        public DeleteShopProductCommandHandler(IMapper mapper, IShopProductRepository shopProductRepository,
                                         ShopProductBusinessRules shopProductBusinessRules)
        {
            _mapper = mapper;
            _shopProductRepository = shopProductRepository;
            _shopProductBusinessRules = shopProductBusinessRules;
        }

        public async Task<DeletedShopProductResponse> Handle(DeleteShopProductCommand request, CancellationToken cancellationToken)
        {
            ShopProduct? shopProduct = await _shopProductRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _shopProductBusinessRules.ShopProductShouldExistWhenSelected(shopProduct);

            await _shopProductRepository.DeleteAsync(shopProduct!);

            DeletedShopProductResponse response = _mapper.Map<DeletedShopProductResponse>(shopProduct);
            return response;
        }
    }
}