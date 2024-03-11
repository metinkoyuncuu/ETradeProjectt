using Application.Features.CustomerCompares.Constants;
using Application.Features.CustomerCompares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCompares.Constants.CustomerComparesOperationClaims;

namespace Application.Features.CustomerCompares.Commands.Create;

public class CreateCustomerCompareCommand : IRequest<CreatedCustomerCompareResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerComparesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCompares";

    public class CreateCustomerCompareCommandHandler : IRequestHandler<CreateCustomerCompareCommand, CreatedCustomerCompareResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCompareRepository _customerCompareRepository;
        private readonly CustomerCompareBusinessRules _customerCompareBusinessRules;

        public CreateCustomerCompareCommandHandler(IMapper mapper, ICustomerCompareRepository customerCompareRepository,
                                         CustomerCompareBusinessRules customerCompareBusinessRules)
        {
            _mapper = mapper;
            _customerCompareRepository = customerCompareRepository;
            _customerCompareBusinessRules = customerCompareBusinessRules;
        }

        public async Task<CreatedCustomerCompareResponse> Handle(CreateCustomerCompareCommand request, CancellationToken cancellationToken)
        {
            CustomerCompare customerCompare = _mapper.Map<CustomerCompare>(request);

            await _customerCompareRepository.AddAsync(customerCompare);

            CreatedCustomerCompareResponse response = _mapper.Map<CreatedCustomerCompareResponse>(customerCompare);
            return response;
        }
    }
}