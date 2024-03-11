using Application.Features.Shippings.Constants;
using Application.Features.Shippings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Shippings.Constants.ShippingsOperationClaims;

namespace Application.Features.Shippings.Queries.GetById;

public class GetByIdShippingQuery : IRequest<GetByIdShippingResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdShippingQueryHandler : IRequestHandler<GetByIdShippingQuery, GetByIdShippingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShippingRepository _shippingRepository;
        private readonly ShippingBusinessRules _shippingBusinessRules;

        public GetByIdShippingQueryHandler(IMapper mapper, IShippingRepository shippingRepository, ShippingBusinessRules shippingBusinessRules)
        {
            _mapper = mapper;
            _shippingRepository = shippingRepository;
            _shippingBusinessRules = shippingBusinessRules;
        }

        public async Task<GetByIdShippingResponse> Handle(GetByIdShippingQuery request, CancellationToken cancellationToken)
        {
            Shipping? shipping = await _shippingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shippingBusinessRules.ShippingShouldExistWhenSelected(shipping);

            GetByIdShippingResponse response = _mapper.Map<GetByIdShippingResponse>(shipping);
            return response;
        }
    }
}