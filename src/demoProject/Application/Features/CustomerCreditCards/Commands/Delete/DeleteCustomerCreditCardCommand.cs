using Application.Features.CustomerCreditCards.Constants;
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

namespace Application.Features.CustomerCreditCards.Commands.Delete;

public class DeleteCustomerCreditCardCommand : IRequest<DeletedCustomerCreditCardResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCreditCardsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCreditCards";

    public class DeleteCustomerCreditCardCommandHandler : IRequestHandler<DeleteCustomerCreditCardCommand, DeletedCustomerCreditCardResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
        private readonly CustomerCreditCardBusinessRules _customerCreditCardBusinessRules;

        public DeleteCustomerCreditCardCommandHandler(IMapper mapper, ICustomerCreditCardRepository customerCreditCardRepository,
                                         CustomerCreditCardBusinessRules customerCreditCardBusinessRules)
        {
            _mapper = mapper;
            _customerCreditCardRepository = customerCreditCardRepository;
            _customerCreditCardBusinessRules = customerCreditCardBusinessRules;
        }

        public async Task<DeletedCustomerCreditCardResponse> Handle(DeleteCustomerCreditCardCommand request, CancellationToken cancellationToken)
        {
            CustomerCreditCard? customerCreditCard = await _customerCreditCardRepository.GetAsync(predicate: ccc => ccc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCreditCardBusinessRules.CustomerCreditCardShouldExistWhenSelected(customerCreditCard);

            await _customerCreditCardRepository.DeleteAsync(customerCreditCard!);

            DeletedCustomerCreditCardResponse response = _mapper.Map<DeletedCustomerCreditCardResponse>(customerCreditCard);
            return response;
        }
    }
}