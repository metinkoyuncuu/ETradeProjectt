using Application.Features.ShopSellers.Constants;
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

namespace Application.Features.ShopSellers.Commands.Delete;

public class DeleteShopSellerCommand : IRequest<DeletedShopSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopSellersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopSellers";

    public class DeleteShopSellerCommandHandler : IRequestHandler<DeleteShopSellerCommand, DeletedShopSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopSellerRepository _shopSellerRepository;
        private readonly ShopSellerBusinessRules _shopSellerBusinessRules;

        public DeleteShopSellerCommandHandler(IMapper mapper, IShopSellerRepository shopSellerRepository,
                                         ShopSellerBusinessRules shopSellerBusinessRules)
        {
            _mapper = mapper;
            _shopSellerRepository = shopSellerRepository;
            _shopSellerBusinessRules = shopSellerBusinessRules;
        }

        public async Task<DeletedShopSellerResponse> Handle(DeleteShopSellerCommand request, CancellationToken cancellationToken)
        {
            ShopSeller? shopSeller = await _shopSellerRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _shopSellerBusinessRules.ShopSellerShouldExistWhenSelected(shopSeller);

            await _shopSellerRepository.DeleteAsync(shopSeller!);

            DeletedShopSellerResponse response = _mapper.Map<DeletedShopSellerResponse>(shopSeller);
            return response;
        }
    }
}