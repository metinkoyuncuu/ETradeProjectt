using Application.Features.ShopSellers.Constants;
using Application.Features.ShopSellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ShopSellers.Constants.ShopSellersOperationClaims;

namespace Application.Features.ShopSellers.Commands.Create;

public class CreateShopSellerCommand : IRequest<CreatedShopSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ShopId { get; set; }
    public int SellerId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopSellersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopSellers";

    public class CreateShopSellerCommandHandler : IRequestHandler<CreateShopSellerCommand, CreatedShopSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopSellerRepository _shopSellerRepository;
        private readonly ShopSellerBusinessRules _shopSellerBusinessRules;

        public CreateShopSellerCommandHandler(IMapper mapper, IShopSellerRepository shopSellerRepository,
                                         ShopSellerBusinessRules shopSellerBusinessRules)
        {
            _mapper = mapper;
            _shopSellerRepository = shopSellerRepository;
            _shopSellerBusinessRules = shopSellerBusinessRules;
        }

        public async Task<CreatedShopSellerResponse> Handle(CreateShopSellerCommand request, CancellationToken cancellationToken)
        {
            ShopSeller shopSeller = _mapper.Map<ShopSeller>(request);

            await _shopSellerRepository.AddAsync(shopSeller);

            CreatedShopSellerResponse response = _mapper.Map<CreatedShopSellerResponse>(shopSeller);
            return response;
        }
    }
}