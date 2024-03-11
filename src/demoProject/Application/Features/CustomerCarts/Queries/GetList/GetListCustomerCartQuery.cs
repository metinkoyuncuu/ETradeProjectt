using Application.Features.CustomerCarts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCarts.Constants.CustomerCartsOperationClaims;

namespace Application.Features.CustomerCarts.Queries.GetList;

public class GetListCustomerCartQuery : IRequest<GetListResponse<GetListCustomerCartListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerCarts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerCarts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerCartQueryHandler : IRequestHandler<GetListCustomerCartQuery, GetListResponse<GetListCustomerCartListItemDto>>
    {
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCartQueryHandler(ICustomerCartRepository customerCartRepository, IMapper mapper)
        {
            _customerCartRepository = customerCartRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCartListItemDto>> Handle(GetListCustomerCartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCart> customerCarts = await _customerCartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCartListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCartListItemDto>>(customerCarts);
            return response;
        }
    }
}