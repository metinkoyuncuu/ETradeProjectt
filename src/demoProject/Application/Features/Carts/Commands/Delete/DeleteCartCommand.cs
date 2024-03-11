using Application.Features.Carts.Constants;
using Application.Features.Carts.Constants;
using Application.Features.Carts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Commands.Delete;

public class DeleteCartCommand : IRequest<DeletedCartResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CartsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCarts";

    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, DeletedCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public DeleteCartCommandHandler(IMapper mapper, ICartRepository cartRepository,
                                         CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<DeletedCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cartBusinessRules.CartShouldExistWhenSelected(cart);

            await _cartRepository.DeleteAsync(cart!);

            DeletedCartResponse response = _mapper.Map<DeletedCartResponse>(cart);
            return response;
        }
    }
}