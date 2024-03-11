using Application.Features.CustomerCarts.Constants;
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

namespace Application.Features.CustomerCarts.Commands.Delete;

public class DeleteCustomerCartCommand : IRequest<DeletedCustomerCartResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCartsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCarts";

    public class DeleteCustomerCartCommandHandler : IRequestHandler<DeleteCustomerCartCommand, DeletedCustomerCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly CustomerCartBusinessRules _customerCartBusinessRules;

        public DeleteCustomerCartCommandHandler(IMapper mapper, ICustomerCartRepository customerCartRepository,
                                         CustomerCartBusinessRules customerCartBusinessRules)
        {
            _mapper = mapper;
            _customerCartRepository = customerCartRepository;
            _customerCartBusinessRules = customerCartBusinessRules;
        }

        public async Task<DeletedCustomerCartResponse> Handle(DeleteCustomerCartCommand request, CancellationToken cancellationToken)
        {
            CustomerCart? customerCart = await _customerCartRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCartBusinessRules.CustomerCartShouldExistWhenSelected(customerCart);

            await _customerCartRepository.DeleteAsync(customerCart!);

            DeletedCustomerCartResponse response = _mapper.Map<DeletedCustomerCartResponse>(customerCart);
            return response;
        }
    }
}