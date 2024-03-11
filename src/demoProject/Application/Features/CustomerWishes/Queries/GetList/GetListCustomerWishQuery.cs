using Application.Features.CustomerWishes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerWishes.Constants.CustomerWishesOperationClaims;

namespace Application.Features.CustomerWishes.Queries.GetList;

public class GetListCustomerWishQuery : IRequest<GetListResponse<GetListCustomerWishListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerWishes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerWishes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerWishQueryHandler : IRequestHandler<GetListCustomerWishQuery, GetListResponse<GetListCustomerWishListItemDto>>
    {
        private readonly ICustomerWishRepository _customerWishRepository;
        private readonly IMapper _mapper;

        public GetListCustomerWishQueryHandler(ICustomerWishRepository customerWishRepository, IMapper mapper)
        {
            _customerWishRepository = customerWishRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerWishListItemDto>> Handle(GetListCustomerWishQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerWish> customerWishes = await _customerWishRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerWishListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerWishListItemDto>>(customerWishes);
            return response;
        }
    }
}