using Application.Features.ProductTags.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductTags.Constants.ProductTagsOperationClaims;

namespace Application.Features.ProductTags.Queries.GetList;

public class GetListProductTagQuery : IRequest<GetListResponse<GetListProductTagListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductTags({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductTags";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductTagQueryHandler : IRequestHandler<GetListProductTagQuery, GetListResponse<GetListProductTagListItemDto>>
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly IMapper _mapper;

        public GetListProductTagQueryHandler(IProductTagRepository productTagRepository, IMapper mapper)
        {
            _productTagRepository = productTagRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductTagListItemDto>> Handle(GetListProductTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductTag> productTags = await _productTagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductTagListItemDto> response = _mapper.Map<GetListResponse<GetListProductTagListItemDto>>(productTags);
            return response;
        }
    }
}