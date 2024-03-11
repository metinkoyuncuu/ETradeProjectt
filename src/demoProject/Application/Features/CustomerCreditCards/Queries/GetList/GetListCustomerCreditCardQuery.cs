using Application.Features.CustomerCreditCards.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerCreditCards.Constants.CustomerCreditCardsOperationClaims;

namespace Application.Features.CustomerCreditCards.Queries.GetList;

public class GetListCustomerCreditCardQuery : IRequest<GetListResponse<GetListCustomerCreditCardListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerCreditCards({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerCreditCards";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerCreditCardQueryHandler : IRequestHandler<GetListCustomerCreditCardQuery, GetListResponse<GetListCustomerCreditCardListItemDto>>
    {
        private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
        private readonly IMapper _mapper;

        public GetListCustomerCreditCardQueryHandler(ICustomerCreditCardRepository customerCreditCardRepository, IMapper mapper)
        {
            _customerCreditCardRepository = customerCreditCardRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerCreditCardListItemDto>> Handle(GetListCustomerCreditCardQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerCreditCard> customerCreditCards = await _customerCreditCardRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerCreditCardListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerCreditCardListItemDto>>(customerCreditCards);
            return response;
        }
    }
}