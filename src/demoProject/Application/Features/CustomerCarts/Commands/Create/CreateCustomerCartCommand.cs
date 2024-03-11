using Application.Features.CustomerCarts.Constants;
using Application.Features.CustomerCarts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCarts.Constants.CustomerCartsOperationClaims;

namespace Application.Features.CustomerCarts.Commands.Create;

public class CreateCustomerCartCommand : IRequest<CreatedCustomerCartResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCartsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCarts";

    public class CreateCustomerCartCommandHandler : IRequestHandler<CreateCustomerCartCommand, CreatedCustomerCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly CustomerCartBusinessRules _customerCartBusinessRules;

        public CreateCustomerCartCommandHandler(IMapper mapper, ICustomerCartRepository customerCartRepository,
                                         CustomerCartBusinessRules customerCartBusinessRules)
        {
            _mapper = mapper;
            _customerCartRepository = customerCartRepository;
            _customerCartBusinessRules = customerCartBusinessRules;
        }

        public async Task<CreatedCustomerCartResponse> Handle(CreateCustomerCartCommand request, CancellationToken cancellationToken)
        {
            CustomerCart customerCart = _mapper.Map<CustomerCart>(request);

            await _customerCartRepository.AddAsync(customerCart);

            CreatedCustomerCartResponse response = _mapper.Map<CreatedCustomerCartResponse>(customerCart);
            return response;
        }
    }
}