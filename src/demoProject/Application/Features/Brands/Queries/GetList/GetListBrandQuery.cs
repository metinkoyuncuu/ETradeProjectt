using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Brands.Constants.BrandsOperationClaims;
using Application.Features.OperationClaims.Constants;
using Application.Services.ContextOperations;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read};

    public bool BypassCache { get; }
    public string CacheKey => $"GetListBrands({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetBrands";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IContextOperationsService _contextOperationsService;
        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, IContextOperationsService contextOperationsService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _contextOperationsService = contextOperationsService;
        }

        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {

            IPaginate<Brand> brands = await _brandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBrandListItemDto> response = _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return response;
        }
    }
}