using Application.Features.ProductFeatureTables.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductFeatureTables.Constants.ProductFeatureTablesOperationClaims;

namespace Application.Features.ProductFeatureTables.Queries.GetList;

public class GetListProductFeatureTableQuery : IRequest<GetListResponse<GetListProductFeatureTableListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductFeatureTables({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductFeatureTables";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductFeatureTableQueryHandler : IRequestHandler<GetListProductFeatureTableQuery, GetListResponse<GetListProductFeatureTableListItemDto>>
    {
        private readonly IProductFeatureTableRepository _productFeatureTableRepository;
        private readonly IMapper _mapper;

        public GetListProductFeatureTableQueryHandler(IProductFeatureTableRepository productFeatureTableRepository, IMapper mapper)
        {
            _productFeatureTableRepository = productFeatureTableRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductFeatureTableListItemDto>> Handle(GetListProductFeatureTableQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductFeatureTable> productFeatureTables = await _productFeatureTableRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductFeatureTableListItemDto> response = _mapper.Map<GetListResponse<GetListProductFeatureTableListItemDto>>(productFeatureTables);
            return response;
        }
    }
}