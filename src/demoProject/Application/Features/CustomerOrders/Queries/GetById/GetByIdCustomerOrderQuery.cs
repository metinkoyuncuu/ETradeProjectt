using Application.Features.CustomerOrders.Constants;
using Application.Features.CustomerOrders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerOrders.Constants.CustomerOrdersOperationClaims;

namespace Application.Features.CustomerOrders.Queries.GetById;

public class GetByIdCustomerOrderQuery : IRequest<GetByIdCustomerOrderResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerOrderQueryHandler : IRequestHandler<GetByIdCustomerOrderQuery, GetByIdCustomerOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly CustomerOrderBusinessRules _customerOrderBusinessRules;

        public GetByIdCustomerOrderQueryHandler(IMapper mapper, ICustomerOrderRepository customerOrderRepository, CustomerOrderBusinessRules customerOrderBusinessRules)
        {
            _mapper = mapper;
            _customerOrderRepository = customerOrderRepository;
            _customerOrderBusinessRules = customerOrderBusinessRules;
        }

        public async Task<GetByIdCustomerOrderResponse> Handle(GetByIdCustomerOrderQuery request, CancellationToken cancellationToken)
        {
            CustomerOrder? customerOrder = await _customerOrderRepository.GetAsync(predicate: co => co.Id == request.Id, cancellationToken: cancellationToken);
            await _customerOrderBusinessRules.CustomerOrderShouldExistWhenSelected(customerOrder);

            GetByIdCustomerOrderResponse response = _mapper.Map<GetByIdCustomerOrderResponse>(customerOrder);
            return response;
        }
    }
}