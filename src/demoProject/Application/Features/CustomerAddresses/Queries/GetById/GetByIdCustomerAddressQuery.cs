using Application.Features.CustomerAddresses.Constants;
using Application.Features.CustomerAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerAddresses.Constants.CustomerAddressesOperationClaims;

namespace Application.Features.CustomerAddresses.Queries.GetById;

public class GetByIdCustomerAddressQuery : IRequest<GetByIdCustomerAddressResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerAddressQueryHandler : IRequestHandler<GetByIdCustomerAddressQuery, GetByIdCustomerAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly CustomerAddressBusinessRules _customerAddressBusinessRules;

        public GetByIdCustomerAddressQueryHandler(IMapper mapper, ICustomerAddressRepository customerAddressRepository, CustomerAddressBusinessRules customerAddressBusinessRules)
        {
            _mapper = mapper;
            _customerAddressRepository = customerAddressRepository;
            _customerAddressBusinessRules = customerAddressBusinessRules;
        }

        public async Task<GetByIdCustomerAddressResponse> Handle(GetByIdCustomerAddressQuery request, CancellationToken cancellationToken)
        {
            CustomerAddress? customerAddress = await _customerAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _customerAddressBusinessRules.CustomerAddressShouldExistWhenSelected(customerAddress);

            GetByIdCustomerAddressResponse response = _mapper.Map<GetByIdCustomerAddressResponse>(customerAddress);
            return response;
        }
    }
}