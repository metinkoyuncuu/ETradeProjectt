using Application.Features.Carts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Queries.GetList;

public class GetListCartQuery : IRequest<GetListResponse<GetListCartListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCarts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCarts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCartQueryHandler : IRequestHandler<GetListCartQuery, GetListResponse<GetListCartListItemDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetListCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCartListItemDto>> Handle(GetListCartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Cart> carts = await _cartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCartListItemDto> response = _mapper.Map<GetListResponse<GetListCartListItemDto>>(carts);
            return response;
        }
    }
}