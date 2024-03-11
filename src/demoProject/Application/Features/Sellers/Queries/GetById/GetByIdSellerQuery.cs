using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Queries.GetById;

public class GetByIdSellerQuery : IRequest<GetByIdSellerResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSellerQueryHandler : IRequestHandler<GetByIdSellerQuery, GetByIdSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public GetByIdSellerQueryHandler(IMapper mapper, ISellerRepository sellerRepository, SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<GetByIdSellerResponse> Handle(GetByIdSellerQuery request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);

            GetByIdSellerResponse response = _mapper.Map<GetByIdSellerResponse>(seller);
            return response;
        }
    }
}