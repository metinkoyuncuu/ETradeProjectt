using Application.Features.Shippings.Constants;
using Application.Features.Shippings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Shippings.Constants.ShippingsOperationClaims;

namespace Application.Features.Shippings.Commands.Create;

public class CreateShippingCommand : IRequest<CreatedShippingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrderId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShippingsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippings";

    public class CreateShippingCommandHandler : IRequestHandler<CreateShippingCommand, CreatedShippingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShippingRepository _shippingRepository;
        private readonly ShippingBusinessRules _shippingBusinessRules;

        public CreateShippingCommandHandler(IMapper mapper, IShippingRepository shippingRepository,
                                         ShippingBusinessRules shippingBusinessRules)
        {
            _mapper = mapper;
            _shippingRepository = shippingRepository;
            _shippingBusinessRules = shippingBusinessRules;
        }

        public async Task<CreatedShippingResponse> Handle(CreateShippingCommand request, CancellationToken cancellationToken)
        {
            Shipping shipping = _mapper.Map<Shipping>(request);

            await _shippingRepository.AddAsync(shipping);

            CreatedShippingResponse response = _mapper.Map<CreatedShippingResponse>(shipping);
            return response;
        }
    }
}