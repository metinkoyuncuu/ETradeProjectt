using Application.Features.CustomerOrders.Constants;
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

namespace Application.Features.CustomerOrders.Commands.Delete;

public class DeleteCustomerOrderCommand : IRequest<DeletedCustomerOrderResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerOrdersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerOrders";

    public class DeleteCustomerOrderCommandHandler : IRequestHandler<DeleteCustomerOrderCommand, DeletedCustomerOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly CustomerOrderBusinessRules _customerOrderBusinessRules;

        public DeleteCustomerOrderCommandHandler(IMapper mapper, ICustomerOrderRepository customerOrderRepository,
                                         CustomerOrderBusinessRules customerOrderBusinessRules)
        {
            _mapper = mapper;
            _customerOrderRepository = customerOrderRepository;
            _customerOrderBusinessRules = customerOrderBusinessRules;
        }

        public async Task<DeletedCustomerOrderResponse> Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            CustomerOrder? customerOrder = await _customerOrderRepository.GetAsync(predicate: co => co.Id == request.Id, cancellationToken: cancellationToken);
            await _customerOrderBusinessRules.CustomerOrderShouldExistWhenSelected(customerOrder);

            await _customerOrderRepository.DeleteAsync(customerOrder!);

            DeletedCustomerOrderResponse response = _mapper.Map<DeletedCustomerOrderResponse>(customerOrder);
            return response;
        }
    }
}