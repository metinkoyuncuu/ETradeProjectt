using Application.Features.ProductFeatures.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductFeatures.Constants.ProductFeaturesOperationClaims;

namespace Application.Features.ProductFeatures.Queries.GetList;

public class GetListProductFeatureQuery : IRequest<GetListResponse<GetListProductFeatureListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductFeatures({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductFeatures";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductFeatureQueryHandler : IRequestHandler<GetListProductFeatureQuery, GetListResponse<GetListProductFeatureListItemDto>>
    {
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly IMapper _mapper;

        public GetListProductFeatureQueryHandler(IProductFeatureRepository productFeatureRepository, IMapper mapper)
        {
            _productFeatureRepository = productFeatureRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductFeatureListItemDto>> Handle(GetListProductFeatureQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductFeature> productFeatures = await _productFeatureRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductFeatureListItemDto> response = _mapper.Map<GetListResponse<GetListProductFeatureListItemDto>>(productFeatures);
            return response;
        }
    }
}