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

namespace Application.Features.Shops.Commands.Update;

public class UpdateShopCommand : IRequest<UpdatedShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? TaxNumber { get; set; }
    public string AccessKey { get; set; }
    public string Address { get; set; }
    public bool IsVerified { get; set; }
    public float Balance { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShops";

    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, UpdatedShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly ShopBusinessRules _shopBusinessRules;

        public UpdateShopCommandHandler(IMapper mapper, IShopRepository shopRepository,
                                         ShopBusinessRules shopBusinessRules)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _shopBusinessRules = shopBusinessRules;
        }

        public async Task<UpdatedShopResponse> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            Shop? shop = await _shopRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shopBusinessRules.ShopShouldExistWhenSelected(shop);
            shop = _mapper.Map(request, shop);

            await _shopRepository.UpdateAsync(shop!);

            UpdatedShopResponse response = _mapper.Map<UpdatedShopResponse>(shop);
            return response;
        }
    }
}