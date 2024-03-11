using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Queries.GetList;

public class GetListSellerQuery : IRequest<GetListResponse<GetListSellerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSellers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSellers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSellerQueryHandler : IRequestHandler<GetListSellerQuery, GetListResponse<GetListSellerListItemDto>>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public GetListSellerQueryHandler(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSellerListItemDto>> Handle(GetListSellerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Seller> sellers = await _sellerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSellerListItemDto> response = _mapper.Map<GetListResponse<GetListSellerListItemDto>>(sellers);
            return response;
        }
    }
}