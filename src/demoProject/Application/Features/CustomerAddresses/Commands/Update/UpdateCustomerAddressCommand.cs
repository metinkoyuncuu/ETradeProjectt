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

namespace Application.Features.CustomerAddresses.Commands.Update;

public class UpdateCustomerAddressCommand : IRequest<UpdatedCustomerAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerAddressesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerAddresses";

    public class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, UpdatedCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressBusinessRules _customerAddressBusinessRules;

        public UpdateCustomerAddressCommandHandler(IMapper mapper, ICustomerAddressRepository customerAddressRepository,
                                         CustomerAddressBusinessRules customerAddressBusinessRules)
        {
            _mapper = mapper;
            _customerAddressRepository = customerAddressRepository;
            _customerAddressBusinessRules = customerAddressBusinessRules;
        }

        public async Task<UpdatedCustomerAddressResponse> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            CustomerAddress? customerAddress = await _customerAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAddressBusinessRules.CustomerAddressShouldExistWhenSelected(customerAddress);
            customerAddress = _mapper.Map(request, customerAddress);

            await _customerAddressRepository.UpdateAsync(customerAddress!);

            UpdatedCustomerAddressResponse response = _mapper.Map<UpdatedCustomerAddressResponse>(customerAddress);
            return response;
        }
    }
}