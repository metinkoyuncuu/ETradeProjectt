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

namespace Application.Features.CustomerOrders.Commands.Update;

public class UpdateCustomerOrderCommand : IRequest<UpdatedCustomerOrderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerOrdersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerOrders";

    public class UpdateCustomerOrderCommandHandler : IRequestHandler<UpdateCustomerOrderCommand, UpdatedCustomerOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly CustomerOrderBusinessRules _customerOrderBusinessRules;

        public UpdateCustomerOrderCommandHandler(IMapper mapper, ICustomerOrderRepository customerOrderRepository,
                                         CustomerOrderBusinessRules customerOrderBusinessRules)
        {
            _mapper = mapper;
            _customerOrderRepository = customerOrderRepository;
            _customerOrderBusinessRules = customerOrderBusinessRules;
        }

        public async Task<UpdatedCustomerOrderResponse> Handle(UpdateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            CustomerOrder? customerOrder = await _customerOrderRepository.GetAsync(predicate: co => co.Id == request.Id, cancellationToken: cancellationToken);
            await _customerOrderBusinessRules.CustomerOrderShouldExistWhenSelected(customerOrder);
            customerOrder = _mapper.Map(request, customerOrder);

            await _customerOrderRepository.UpdateAsync(customerOrder!);

            UpdatedCustomerOrderResponse response = _mapper.Map<UpdatedCustomerOrderResponse>(customerOrder);
            return response;
        }
    }
}