using Application.Features.Shops.Constants;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Shops.Constants.ShopsOperationClaims;

namespace Application.Features.Shops.Queries.GetById;

public class GetByIdShopQuery : IRequest<GetByIdShopResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShopQueryHandler : IRequestHandler<GetByIdShopQuery, GetByIdShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly ShopBusinessRules _shopBusinessRules;

        public GetByIdShopQueryHandler(IMapper mapper, IShopRepository shopRepository, ShopBusinessRules shopBusinessRules)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _shopBusinessRules = shopBusinessRules;
        }

        public async Task<GetByIdShopResponse> Handle(GetByIdShopQuery request, CancellationToken cancellationToken)
        {
            Shop? shop = await _shopRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shopBusinessRules.ShopShouldExistWhenSelected(shop);

            GetByIdShopResponse response = _mapper.Map<GetByIdShopResponse>(shop);
            return response;
        }
    }
}