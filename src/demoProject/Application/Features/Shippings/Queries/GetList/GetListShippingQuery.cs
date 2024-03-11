using Application.Features.Shippings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Shippings.Constants.ShippingsOperationClaims;

namespace Application.Features.Shippings.Queries.GetList;

public class GetListShippingQuery : IRequest<GetListResponse<GetListShippingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShippings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShippings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShippingQueryHandler : IRequestHandler<GetListShippingQuery, GetListResponse<GetListShippingListItemDto>>
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public GetListShippingQueryHandler(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShippingListItemDto>> Handle(GetListShippingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Shipping> shippings = await _shippingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShippingListItemDto> response = _mapper.Map<GetListResponse<GetListShippingListItemDto>>(shippings);
            return response;
        }
    }
}