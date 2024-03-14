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
using Application.Features.Brands.Queries.GetListOutsideAdmin;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandOutsideAdminQuery : IRequest<List<Brand>>, ISecuredRequest, ICachableRequest
{
    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Seller, GeneralOperationClaims.Customer };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListBrands()";
    public string CacheGroupKey => "GetBrands";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBrandOutsideAdminQueryHandler : IRequestHandler<GetListBrandOutsideAdminQuery, List<Brand>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public GetListBrandOutsideAdminQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<Brand>> Handle(GetListBrandOutsideAdminQuery request, CancellationToken cancellationToken)
        {

            List<Brand> brands = _brandRepository.GetAll(b=>b.IsVerified==true);
            return brands;
        }
    }
}