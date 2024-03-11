using Application.Features.CustomerCreditCards.Constants;
using Application.Features.CustomerCreditCards.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCreditCards.Constants.CustomerCreditCardsOperationClaims;

namespace Application.Features.CustomerCreditCards.Commands.Create;

public class CreateCustomerCreditCardCommand : IRequest<CreatedCustomerCreditCardResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public string CardType { get; set; }
    public string HolderName { get; set; }
    public string ExpireMonth { get; set; }
    public string ExpireYear { get; set; }
    public string CVV { get; set; }
    public string CardNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCreditCardsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCreditCards";

    public class CreateCustomerCreditCardCommandHandler : IRequestHandler<CreateCustomerCreditCardCommand, CreatedCustomerCreditCardResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
        private readonly CustomerCreditCardBusinessRules _customerCreditCardBusinessRules;

        public CreateCustomerCreditCardCommandHandler(IMapper mapper, ICustomerCreditCardRepository customerCreditCardRepository,
                                         CustomerCreditCardBusinessRules customerCreditCardBusinessRules)
        {
            _mapper = mapper;
            _customerCreditCardRepository = customerCreditCardRepository;
            _customerCreditCardBusinessRules = customerCreditCardBusinessRules;
        }

        public async Task<CreatedCustomerCreditCardResponse> Handle(CreateCustomerCreditCardCommand request, CancellationToken cancellationToken)
        {
            CustomerCreditCard customerCreditCard = _mapper.Map<CustomerCreditCard>(request);

            await _customerCreditCardRepository.AddAsync(customerCreditCard);

            CreatedCustomerCreditCardResponse response = _mapper.Map<CreatedCustomerCreditCardResponse>(customerCreditCard);
            return response;
        }
    }
}