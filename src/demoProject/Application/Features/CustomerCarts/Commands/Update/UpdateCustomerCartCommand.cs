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

namespace Application.Features.CustomerCarts.Commands.Update;

public class UpdateCustomerCartCommand : IRequest<UpdatedCustomerCartResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCartsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCarts";

    public class UpdateCustomerCartCommandHandler : IRequestHandler<UpdateCustomerCartCommand, UpdatedCustomerCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCartRepository _customerCartRepository;
        private readonly CustomerCartBusinessRules _customerCartBusinessRules;

        public UpdateCustomerCartCommandHandler(IMapper mapper, ICustomerCartRepository customerCartRepository,
                                         CustomerCartBusinessRules customerCartBusinessRules)
        {
            _mapper = mapper;
            _customerCartRepository = customerCartRepository;
            _customerCartBusinessRules = customerCartBusinessRules;
        }

        public async Task<UpdatedCustomerCartResponse> Handle(UpdateCustomerCartCommand request, CancellationToken cancellationToken)
        {
            CustomerCart? customerCart = await _customerCartRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCartBusinessRules.CustomerCartShouldExistWhenSelected(customerCart);
            customerCart = _mapper.Map(request, customerCart);

            await _customerCartRepository.UpdateAsync(customerCart!);

            UpdatedCustomerCartResponse response = _mapper.Map<UpdatedCustomerCartResponse>(customerCart);
            return response;
        }
    }
}