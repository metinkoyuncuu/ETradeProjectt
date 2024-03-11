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

namespace Application.Features.Shops.Commands.Create;

public class CreateShopCommand : IRequest<CreatedShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string? TaxNumber { get; set; }
    public string AccessKey { get; set; }
    public string Address { get; set; }
    public bool IsVerified { get; set; }
    public float Balance { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShops";

    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, CreatedShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly ShopBusinessRules _shopBusinessRules;

        public CreateShopCommandHandler(IMapper mapper, IShopRepository shopRepository,
                                         ShopBusinessRules shopBusinessRules)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _shopBusinessRules = shopBusinessRules;
        }

        public async Task<CreatedShopResponse> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            Shop shop = _mapper.Map<Shop>(request);

            await _shopRepository.AddAsync(shop);

            CreatedShopResponse response = _mapper.Map<CreatedShopResponse>(shop);
            return response;
        }
    }
}