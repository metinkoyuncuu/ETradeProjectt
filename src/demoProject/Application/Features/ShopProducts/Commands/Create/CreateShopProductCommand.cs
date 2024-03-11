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

namespace Application.Features.ShopProducts.Commands.Create;

public class CreateShopProductCommand : IRequest<CreatedShopProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopProductsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopProducts";

    public class CreateShopProductCommandHandler : IRequestHandler<CreateShopProductCommand, CreatedShopProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopProductRepository _shopProductRepository;
        private readonly ShopProductBusinessRules _shopProductBusinessRules;

        public CreateShopProductCommandHandler(IMapper mapper, IShopProductRepository shopProductRepository,
                                         ShopProductBusinessRules shopProductBusinessRules)
        {
            _mapper = mapper;
            _shopProductRepository = shopProductRepository;
            _shopProductBusinessRules = shopProductBusinessRules;
        }

        public async Task<CreatedShopProductResponse> Handle(CreateShopProductCommand request, CancellationToken cancellationToken)
        {
            ShopProduct shopProduct = _mapper.Map<ShopProduct>(request);

            await _shopProductRepository.AddAsync(shopProduct);

            CreatedShopProductResponse response = _mapper.Map<CreatedShopProductResponse>(shopProduct);
            return response;
        }
    }
}