using Application.Features.CustomerCompares.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCompares.Constants.CustomerComparesOperationClaims;

namespace Application.Features.CustomerCompares.Queries.GetList;

public class GetListCustomerCompareQuery : IRequest<GetListResponse<GetListCustomerCompareListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerCompares({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerCompares";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerCompareQueryHandler : IRequestHandler<GetListCustomerCompareQuery, GetListResponse<GetListCustomerCompareListItemDto>>
    {
        private readonly ICustomerCompareRepository _customerCompareRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCompareQueryHandler(ICustomerCompareRepository customerCompareRepository, IMapper mapper)
        {
            _customerCompareRepository = customerCompareRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCompareListItemDto>> Handle(GetListCustomerCompareQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCompare> customerCompares = await _customerCompareRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCompareListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCompareListItemDto>>(customerCompares);
            return response;
        }
    }
}