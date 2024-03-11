using Application.Features.CustomerOrders.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerOrders.Constants.CustomerOrdersOperationClaims;

namespace Application.Features.CustomerOrders.Queries.GetList;

public class GetListCustomerOrderQuery : IRequest<GetListResponse<GetListCustomerOrderListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerOrders({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerOrders";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerOrderQueryHandler : IRequestHandler<GetListCustomerOrderQuery, GetListResponse<GetListCustomerOrderListItemDto>>
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly IMapper _mapper;

        public GetListCustomerOrderQueryHandler(ICustomerOrderRepository customerOrderRepository, IMapper mapper)
        {
            _customerOrderRepository = customerOrderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerOrderListItemDto>> Handle(GetListCustomerOrderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerOrder> customerOrders = await _customerOrderRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerOrderListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerOrderListItemDto>>(customerOrders);
            return response;
        }
    }
}