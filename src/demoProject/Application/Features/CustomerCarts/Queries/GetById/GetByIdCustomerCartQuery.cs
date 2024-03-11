using Application.Features.CustomerCarts.Constants;
using Application.Features.CustomerCarts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCarts.Constants.CustomerCartsOperationClaims;

namespace Application.Features.CustomerCarts.Queries.GetById;

public class GetByIdCustomerCartQuery : IRequest<GetByIdCustomerCartResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCartQueryHandler : IRequestHandler<GetByIdCustomerCartQuery, GetByIdCustomerCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly CustomerCartBusinessRules _customerCartBusinessRules;

        public GetByIdCustomerCartQueryHandler(IMapper mapper, ICustomerCartRepository customerCartRepository, CustomerCartBusinessRules customerCartBusinessRules)
        {
            _mapper = mapper;
            _customerCartRepository = customerCartRepository;
            _customerCartBusinessRules = customerCartBusinessRules;
        }

        public async Task<GetByIdCustomerCartResponse> Handle(GetByIdCustomerCartQuery request, CancellationToken cancellationToken)
        {
            CustomerCart? customerCart = await _customerCartRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCartBusinessRules.CustomerCartShouldExistWhenSelected(customerCart);

            GetByIdCustomerCartResponse response = _mapper.Map<GetByIdCustomerCartResponse>(customerCart);
            return response;
        }
    }
}