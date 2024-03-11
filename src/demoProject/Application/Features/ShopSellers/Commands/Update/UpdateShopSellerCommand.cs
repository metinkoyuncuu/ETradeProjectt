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

namespace Application.Features.ShopSellers.Commands.Update;

public class UpdateShopSellerCommand : IRequest<UpdatedShopSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int SellerId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopSellersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopSellers";

    public class UpdateShopSellerCommandHandler : IRequestHandler<UpdateShopSellerCommand, UpdatedShopSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopSellerRepository _shopSellerRepository;
        private readonly ShopSellerBusinessRules _shopSellerBusinessRules;

        public UpdateShopSellerCommandHandler(IMapper mapper, IShopSellerRepository shopSellerRepository,
                                         ShopSellerBusinessRules shopSellerBusinessRules)
        {
            _mapper = mapper;
            _shopSellerRepository = shopSellerRepository;
            _shopSellerBusinessRules = shopSellerBusinessRules;
        }

        public async Task<UpdatedShopSellerResponse> Handle(UpdateShopSellerCommand request, CancellationToken cancellationToken)
        {
            ShopSeller? shopSeller = await _shopSellerRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _shopSellerBusinessRules.ShopSellerShouldExistWhenSelected(shopSeller);
            shopSeller = _mapper.Map(request, shopSeller);

            await _shopSellerRepository.UpdateAsync(shopSeller!);

            UpdatedShopSellerResponse response = _mapper.Map<UpdatedShopSellerResponse>(shopSeller);
            return response;
        }
    }
}