using Application.Features.ShopImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ShopImages.Constants.ShopImagesOperationClaims;

namespace Application.Features.ShopImages.Queries.GetList;

public class GetListShopImageQuery : IRequest<GetListResponse<GetListShopImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShopImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShopImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShopImageQueryHandler : IRequestHandler<GetListShopImageQuery, GetListResponse<GetListShopImageListItemDto>>
    {
        private readonly IShopImageRepository _shopImageRepository;
        private readonly IMapper _mapper;

        public GetListShopImageQueryHandler(IShopImageRepository shopImageRepository, IMapper mapper)
        {
            _shopImageRepository = shopImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShopImageListItemDto>> Handle(GetListShopImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ShopImage> shopImages = await _shopImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShopImageListItemDto> response = _mapper.Map<GetListResponse<GetListShopImageListItemDto>>(shopImages);
            return response;
        }
    }
}