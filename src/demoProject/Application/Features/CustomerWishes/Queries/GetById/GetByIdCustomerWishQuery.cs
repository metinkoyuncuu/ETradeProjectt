using Application.Features.CustomerWishes.Constants;
using Application.Features.CustomerWishes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerWishes.Constants.CustomerWishesOperationClaims;

namespace Application.Features.CustomerWishes.Queries.GetById;

public class GetByIdCustomerWishQuery : IRequest<GetByIdCustomerWishResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerWishQueryHandler : IRequestHandler<GetByIdCustomerWishQuery, GetByIdCustomerWishResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerWishRepository _customerWishRepository;
        private readonly CustomerWishBusinessRules _customerWishBusinessRules;

        public GetByIdCustomerWishQueryHandler(IMapper mapper, ICustomerWishRepository customerWishRepository, CustomerWishBusinessRules customerWishBusinessRules)
        {
            _mapper = mapper;
            _customerWishRepository = customerWishRepository;
            _customerWishBusinessRules = customerWishBusinessRules;
        }

        public async Task<GetByIdCustomerWishResponse> Handle(GetByIdCustomerWishQuery request, CancellationToken cancellationToken)
        {
            CustomerWish? customerWish = await _customerWishRepository.GetAsync(predicate: cw => cw.Id == request.Id, cancellationToken: cancellationToken);
            await _customerWishBusinessRules.CustomerWishShouldExistWhenSelected(customerWish);

            GetByIdCustomerWishResponse response = _mapper.Map<GetByIdCustomerWishResponse>(customerWish);
            return response;
        }
    }
}