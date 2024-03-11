using Application.Features.ProductCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductCategories.Constants.ProductCategoriesOperationClaims;

namespace Application.Features.ProductCategories.Queries.GetList;

public class GetListProductCategoryQuery : IRequest<GetListResponse<GetListProductCategoryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductCategoryQueryHandler : IRequestHandler<GetListProductCategoryQuery, GetListResponse<GetListProductCategoryListItemDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetListProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductCategoryListItemDto>> Handle(GetListProductCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductCategory> productCategories = await _productCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListProductCategoryListItemDto>>(productCategories);
            return response;
        }
    }
}