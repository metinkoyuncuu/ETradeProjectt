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

namespace Application.Features.CustomerWishes.Commands.Update;

public class UpdateCustomerWishCommand : IRequest<UpdatedCustomerWishResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerWishesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerWishes";

    public class UpdateCustomerWishCommandHandler : IRequestHandler<UpdateCustomerWishCommand, UpdatedCustomerWishResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerWishRepository _customerWishRepository;
        private readonly CustomerWishBusinessRules _customerWishBusinessRules;

        public UpdateCustomerWishCommandHandler(IMapper mapper, ICustomerWishRepository customerWishRepository,
                                         CustomerWishBusinessRules customerWishBusinessRules)
        {
            _mapper = mapper;
            _customerWishRepository = customerWishRepository;
            _customerWishBusinessRules = customerWishBusinessRules;
        }

        public async Task<UpdatedCustomerWishResponse> Handle(UpdateCustomerWishCommand request, CancellationToken cancellationToken)
        {
            CustomerWish? customerWish = await _customerWishRepository.GetAsync(predicate: cw => cw.Id == request.Id, cancellationToken: cancellationToken);
            await _customerWishBusinessRules.CustomerWishShouldExistWhenSelected(customerWish);
            customerWish = _mapper.Map(request, customerWish);

            await _customerWishRepository.UpdateAsync(customerWish!);

            UpdatedCustomerWishResponse response = _mapper.Map<UpdatedCustomerWishResponse>(customerWish);
            return response;
        }
    }
}