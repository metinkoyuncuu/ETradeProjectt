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

namespace Application.Features.Carts.Commands.Create;

public class CreateCartCommand : IRequest<CreatedCartResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CouponId { get; set; }

    public string[] Roles => new[] { Admin, Write, CartsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCarts";

    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CreatedCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public CreateCartCommandHandler(IMapper mapper, ICartRepository cartRepository,
                                         CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<CreatedCartResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Cart cart = _mapper.Map<Cart>(request);

            await _cartRepository.AddAsync(cart);

            CreatedCartResponse response = _mapper.Map<CreatedCartResponse>(cart);
            return response;
        }
    }
}