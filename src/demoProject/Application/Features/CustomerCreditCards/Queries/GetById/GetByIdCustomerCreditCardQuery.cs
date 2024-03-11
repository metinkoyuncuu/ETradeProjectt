using Application.Features.CustomerCreditCards.Constants;
using Application.Features.CustomerCreditCards.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCreditCards.Constants.CustomerCreditCardsOperationClaims;

namespace Application.Features.CustomerCreditCards.Queries.GetById;

public class GetByIdCustomerCreditCardQuery : IRequest<GetByIdCustomerCreditCardResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCreditCardQueryHandler : IRequestHandler<GetByIdCustomerCreditCardQuery, GetByIdCustomerCreditCardResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
        private readonly CustomerCreditCardBusinessRules _customerCreditCardBusinessRules;

        public GetByIdCustomerCreditCardQueryHandler(IMapper mapper, ICustomerCreditCardRepository customerCreditCardRepository, CustomerCreditCardBusinessRules customerCreditCardBusinessRules)
        {
            _mapper = mapper;
            _customerCreditCardRepository = customerCreditCardRepository;
            _customerCreditCardBusinessRules = customerCreditCardBusinessRules;
        }

        public async Task<GetByIdCustomerCreditCardResponse> Handle(GetByIdCustomerCreditCardQuery request, CancellationToken cancellationToken)
        {
            CustomerCreditCard? customerCreditCard = await _customerCreditCardRepository.GetAsync(predicate: ccc => ccc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCreditCardBusinessRules.CustomerCreditCardShouldExistWhenSelected(customerCreditCard);

            GetByIdCustomerCreditCardResponse response = _mapper.Map<GetByIdCustomerCreditCardResponse>(customerCreditCard);
            return response;
        }
    }
}