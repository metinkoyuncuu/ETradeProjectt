using Application.Features.CustomerOrders.Constants;
using Application.Features.CustomerOrders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerOrders.Constants.CustomerOrdersOperationClaims;

namespace Application.Features.CustomerOrders.Commands.Create;

public class CreateCustomerOrderCommand : IRequest<CreatedCustomerOrderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int OrderId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerOrdersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerOrders";

    public class CreateCustomerOrderCommandHandler : IRequestHandler<CreateCustomerOrderCommand, CreatedCustomerOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly CustomerOrderBusinessRules _customerOrderBusinessRules;

        public CreateCustomerOrderCommandHandler(IMapper mapper, ICustomerOrderRepository customerOrderRepository,
                                         CustomerOrderBusinessRules customerOrderBusinessRules)
        {
            _mapper = mapper;
            _customerOrderRepository = customerOrderRepository;
            _customerOrderBusinessRules = customerOrderBusinessRules;
        }

        public async Task<CreatedCustomerOrderResponse> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            CustomerOrder customerOrder = _mapper.Map<CustomerOrder>(request);

            await _customerOrderRepository.AddAsync(customerOrder);

            CreatedCustomerOrderResponse response = _mapper.Map<CreatedCustomerOrderResponse>(customerOrder);
            return response;
        }
    }
}