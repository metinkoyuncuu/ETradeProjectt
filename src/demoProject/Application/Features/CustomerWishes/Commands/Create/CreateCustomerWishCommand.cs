using Application.Features.CustomerWishes.Constants;
using Application.Features.CustomerWishes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerWishes.Constants.CustomerWishesOperationClaims;

namespace Application.Features.CustomerWishes.Commands.Create;

public class CreateCustomerWishCommand : IRequest<CreatedCustomerWishResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerWishesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerWishes";

    public class CreateCustomerWishCommandHandler : IRequestHandler<CreateCustomerWishCommand, CreatedCustomerWishResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerWishRepository _customerWishRepository;
        private readonly CustomerWishBusinessRules _customerWishBusinessRules;

        public CreateCustomerWishCommandHandler(IMapper mapper, ICustomerWishRepository customerWishRepository,
                                         CustomerWishBusinessRules customerWishBusinessRules)
        {
            _mapper = mapper;
            _customerWishRepository = customerWishRepository;
            _customerWishBusinessRules = customerWishBusinessRules;
        }

        public async Task<CreatedCustomerWishResponse> Handle(CreateCustomerWishCommand request, CancellationToken cancellationToken)
        {
            CustomerWish customerWish = _mapper.Map<CustomerWish>(request);

            await _customerWishRepository.AddAsync(customerWish);

            CreatedCustomerWishResponse response = _mapper.Map<CreatedCustomerWishResponse>(customerWish);
            return response;
        }
    }
}