using Application.Features.ProductColors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Queries.GetList;

public class GetListProductColorQuery : IRequest<GetListResponse<GetListProductColorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductColors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductColors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductColorQueryHandler : IRequestHandler<GetListProductColorQuery, GetListResponse<GetListProductColorListItemDto>>
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IMapper _mapper;

        public GetListProductColorQueryHandler(IProductColorRepository productColorRepository, IMapper mapper)
        {
            _productColorRepository = productColorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductColorListItemDto>> Handle(GetListProductColorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductColor> productColors = await _productColorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductColorListItemDto> response = _mapper.Map<GetListResponse<GetListProductColorListItemDto>>(productColors);
            return response;
        }
    }
}