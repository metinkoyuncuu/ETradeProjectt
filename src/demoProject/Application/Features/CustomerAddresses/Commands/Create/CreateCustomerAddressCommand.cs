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

namespace Application.Features.CustomerAddresses.Commands.Create;

public class CreateCustomerAddressCommand : IRequest<CreatedCustomerAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerAddressesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerAddresses";

    public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateCustomerAddressCommand, CreatedCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressBusinessRules _customerAddressBusinessRules;

        public CreateCustomerAddressCommandHandler(IMapper mapper, ICustomerAddressRepository customerAddressRepository,
                                         CustomerAddressBusinessRules customerAddressBusinessRules)
        {
            _mapper = mapper;
            _customerAddressRepository = customerAddressRepository;
            _customerAddressBusinessRules = customerAddressBusinessRules;
        }

        public async Task<CreatedCustomerAddressResponse> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            CustomerAddress customerAddress = _mapper.Map<CustomerAddress>(request);

            await _customerAddressRepository.AddAsync(customerAddress);

            CreatedCustomerAddressResponse response = _mapper.Map<CreatedCustomerAddressResponse>(customerAddress);
            return response;
        }
    }
}