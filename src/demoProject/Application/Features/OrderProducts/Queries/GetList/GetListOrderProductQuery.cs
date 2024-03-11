using Application.Features.OrderProducts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.OrderProducts.Constants.OrderProductsOperationClaims;

namespace Application.Features.OrderProducts.Queries.GetList;

public class GetListOrderProductQuery : IRequest<GetListResponse<GetListOrderProductListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListOrderProducts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetOrderProducts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderProductQueryHandler : IRequestHandler<GetListOrderProductQuery, GetListResponse<GetListOrderProductListItemDto>>
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;

        public GetListOrderProductQueryHandler(IOrderProductRepository orderProductRepository, IMapper mapper)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderProductListItemDto>> Handle(GetListOrderProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderProduct> orderProducts = await _orderProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderProductListItemDto> response = _mapper.Map<GetListResponse<GetListOrderProductListItemDto>>(orderProducts);
            return response;
        }
    }
}