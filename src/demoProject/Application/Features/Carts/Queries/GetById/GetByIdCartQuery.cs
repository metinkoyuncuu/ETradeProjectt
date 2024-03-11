using Application.Features.Carts.Constants;
using Application.Features.Carts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Carts.Constants.CartsOperationClaims;

namespace Application.Features.Carts.Queries.GetById;

public class GetByIdCartQuery : IRequest<GetByIdCartResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCartQueryHandler : IRequestHandler<GetByIdCartQuery, GetByIdCartResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly CartBusinessRules _cartBusinessRules;

        public GetByIdCartQueryHandler(IMapper mapper, ICartRepository cartRepository, CartBusinessRules cartBusinessRules)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartBusinessRules = cartBusinessRules;
        }

        public async Task<GetByIdCartResponse> Handle(GetByIdCartQuery request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cartBusinessRules.CartShouldExistWhenSelected(cart);

            GetByIdCartResponse response = _mapper.Map<GetByIdCartResponse>(cart);
            return response;
        }
    }
}