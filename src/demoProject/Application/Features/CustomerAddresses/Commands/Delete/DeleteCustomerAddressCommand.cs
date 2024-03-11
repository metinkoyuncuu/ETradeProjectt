using Application.Features.CustomerAddresses.Constants;
using Application.Features.CustomerAddresses.Constants;
using Application.Features.CustomerAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerAddresses.Constants.CustomerAddressesOperationClaims;

namespace Application.Features.CustomerAddresses.Commands.Delete;

public class DeleteCustomerAddressCommand : IRequest<DeletedCustomerAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerAddressesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerAddresses";

    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, DeletedCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressBusinessRules _customerAddressBusinessRules;

        public DeleteCustomerAddressCommandHandler(IMapper mapper, ICustomerAddressRepository customerAddressRepository,
                                         CustomerAddressBusinessRules customerAddressBusinessRules)
        {
            _mapper = mapper;
            _customerAddressRepository = customerAddressRepository;
            _customerAddressBusinessRules = customerAddressBusinessRules;
        }

        public async Task<DeletedCustomerAddressResponse> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            CustomerAddress? customerAddress = await _customerAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAddressBusinessRules.CustomerAddressShouldExistWhenSelected(customerAddress);

            await _customerAddressRepository.DeleteAsync(customerAddress!);

            DeletedCustomerAddressResponse response = _mapper.Map<DeletedCustomerAddressResponse>(customerAddress);
            return response;
        }
    }
}