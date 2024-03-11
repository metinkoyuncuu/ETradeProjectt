using Application.Features.Shops.Constants;
using Application.Features.Shops.Constants;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Shops.Constants.ShopsOperationClaims;

namespace Application.Features.Shops.Commands.Delete;

public class DeleteShopCommand : IRequest<DeletedShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShops";

    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand, DeletedShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly ShopBusinessRules _shopBusinessRules;

        public DeleteShopCommandHandler(IMapper mapper, IShopRepository shopRepository,
                                         ShopBusinessRules shopBusinessRules)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _shopBusinessRules = shopBusinessRules;
        }

        public async Task<DeletedShopResponse> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            Shop? shop = await _shopRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shopBusinessRules.ShopShouldExistWhenSelected(shop);

            await _shopRepository.DeleteAsync(shop!);

            DeletedShopResponse response = _mapper.Map<DeletedShopResponse>(shop);
            return response;
        }
    }
}