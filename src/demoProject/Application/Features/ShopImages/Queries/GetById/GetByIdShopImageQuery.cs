using Application.Features.ShopImages.Constants;
using Application.Features.ShopImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ShopImages.Constants.ShopImagesOperationClaims;

namespace Application.Features.ShopImages.Queries.GetById;

public class GetByIdShopImageQuery : IRequest<GetByIdShopImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShopImageQueryHandler : IRequestHandler<GetByIdShopImageQuery, GetByIdShopImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopImageRepository _shopImageRepository;
        private readonly ShopImageBusinessRules _shopImageBusinessRules;

        public GetByIdShopImageQueryHandler(IMapper mapper, IShopImageRepository shopImageRepository, ShopImageBusinessRules shopImageBusinessRules)
        {
            _mapper = mapper;
            _shopImageRepository = shopImageRepository;
            _shopImageBusinessRules = shopImageBusinessRules;
        }

        public async Task<GetByIdShopImageResponse> Handle(GetByIdShopImageQuery request, CancellationToken cancellationToken)
        {
            ShopImage? shopImage = await _shopImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _shopImageBusinessRules.ShopImageShouldExistWhenSelected(shopImage);

            GetByIdShopImageResponse response = _mapper.Map<GetByIdShopImageResponse>(shopImage);
            return response;
        }
    }
}