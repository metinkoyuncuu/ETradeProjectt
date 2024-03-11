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

namespace Application.Features.CustomerCreditCards.Commands.Update;

public class UpdateCustomerCreditCardCommand : IRequest<UpdatedCustomerCreditCardResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CardType { get; set; }
    public string HolderName { get; set; }
    public string ExpireMonth { get; set; }
    public string ExpireYear { get; set; }
    public string CVV { get; set; }
    public string CardNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCreditCardsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCreditCards";

    public class UpdateCustomerCreditCardCommandHandler : IRequestHandler<UpdateCustomerCreditCardCommand, UpdatedCustomerCreditCardResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
        private readonly CustomerCreditCardBusinessRules _customerCreditCardBusinessRules;

        public UpdateCustomerCreditCardCommandHandler(IMapper mapper, ICustomerCreditCardRepository customerCreditCardRepository,
                                         CustomerCreditCardBusinessRules customerCreditCardBusinessRules)
        {
            _mapper = mapper;
            _customerCreditCardRepository = customerCreditCardRepository;
            _customerCreditCardBusinessRules = customerCreditCardBusinessRules;
        }

        public async Task<UpdatedCustomerCreditCardResponse> Handle(UpdateCustomerCreditCardCommand request, CancellationToken cancellationToken)
        {
            CustomerCreditCard? customerCreditCard = await _customerCreditCardRepository.GetAsync(predicate: ccc => ccc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCreditCardBusinessRules.CustomerCreditCardShouldExistWhenSelected(customerCreditCard);
            customerCreditCard = _mapper.Map(request, customerCreditCard);

            await _customerCreditCardRepository.UpdateAsync(customerCreditCard!);

            UpdatedCustomerCreditCardResponse response = _mapper.Map<UpdatedCustomerCreditCardResponse>(customerCreditCard);
            return response;
        }
    }
}