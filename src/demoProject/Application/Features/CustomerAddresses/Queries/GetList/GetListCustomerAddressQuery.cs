using Application.Features.CustomerAddresses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerAddresses.Constants.CustomerAddressesOperationClaims;

namespace Application.Features.CustomerAddresses.Queries.GetList;

public class GetListCustomerAddressQuery : IRequest<GetListResponse<GetListCustomerAddressListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerAddresses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerAddresses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerAddressQueryHandler : IRequestHandler<GetListCustomerAddressQuery, GetListResponse<GetListCustomerAddressListItemDto>>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public GetListCustomerAddressQueryHandler(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerAddressListItemDto>> Handle(GetListCustomerAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerAddress> customerAddresses = await _customerAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerAddressListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerAddressListItemDto>>(customerAddresses);
            return response;
        }
    }
}