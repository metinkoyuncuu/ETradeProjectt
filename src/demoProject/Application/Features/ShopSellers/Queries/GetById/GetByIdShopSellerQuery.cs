using Application.Features.ShopSellers.Constants;
using Application.Features.ShopSellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ShopSellers.Constants.ShopSellersOperationClaims;

namespace Application.Features.ShopSellers.Queries.GetById;

public class GetByIdShopSellerQuery : IRequest<GetByIdShopSellerResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShopSellerQueryHandler : IRequestHandler<GetByIdShopSellerQuery, GetByIdShopSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopSellerRepository _shopSellerRepository;
        private readonly ShopSellerBusinessRules _shopSellerBusinessRules;

        public GetByIdShopSellerQueryHandler(IMapper mapper, IShopSellerRepository shopSellerRepository, ShopSellerBusinessRules shopSellerBusinessRules)
        {
            _mapper = mapper;
            _shopSellerRepository = shopSellerRepository;
            _shopSellerBusinessRules = shopSellerBusinessRules;
        }

        public async Task<GetByIdShopSellerResponse> Handle(GetByIdShopSellerQuery request, CancellationToken cancellationToken)
        {
            ShopSeller? shopSeller = await _shopSellerRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _shopSellerBusinessRules.ShopSellerShouldExistWhenSelected(shopSeller);

            GetByIdShopSellerResponse response = _mapper.Map<GetByIdShopSellerResponse>(shopSeller);
            return response;
        }
    }
}