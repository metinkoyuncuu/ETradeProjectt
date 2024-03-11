using Application.Features.CustomerWishes.Constants;
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

namespace Application.Features.CustomerWishes.Commands.Delete;

public class DeleteCustomerWishCommand : IRequest<DeletedCustomerWishResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerWishesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerWishes";

    public class DeleteCustomerWishCommandHandler : IRequestHandler<DeleteCustomerWishCommand, DeletedCustomerWishResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerWishRepository _customerWishRepository;
        private readonly CustomerWishBusinessRules _customerWishBusinessRules;

        public DeleteCustomerWishCommandHandler(IMapper mapper, ICustomerWishRepository customerWishRepository,
                                         CustomerWishBusinessRules customerWishBusinessRules)
        {
            _mapper = mapper;
            _customerWishRepository = customerWishRepository;
            _customerWishBusinessRules = customerWishBusinessRules;
        }

        public async Task<DeletedCustomerWishResponse> Handle(DeleteCustomerWishCommand request, CancellationToken cancellationToken)
        {
            CustomerWish? customerWish = await _customerWishRepository.GetAsync(predicate: cw => cw.Id == request.Id, cancellationToken: cancellationToken);
            await _customerWishBusinessRules.CustomerWishShouldExistWhenSelected(customerWish);

            await _customerWishRepository.DeleteAsync(customerWish!);

            DeletedCustomerWishResponse response = _mapper.Map<DeletedCustomerWishResponse>(customerWish);
            return response;
        }
    }
}