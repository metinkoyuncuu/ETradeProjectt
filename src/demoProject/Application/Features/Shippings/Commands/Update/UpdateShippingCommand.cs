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

namespace Application.Features.Shippings.Commands.Update;

public class UpdateShippingCommand : IRequest<UpdatedShippingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShippingsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippings";

    public class UpdateShippingCommandHandler : IRequestHandler<UpdateShippingCommand, UpdatedShippingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShippingRepository _shippingRepository;
        private readonly ShippingBusinessRules _shippingBusinessRules;

        public UpdateShippingCommandHandler(IMapper mapper, IShippingRepository shippingRepository,
                                         ShippingBusinessRules shippingBusinessRules)
        {
            _mapper = mapper;
            _shippingRepository = shippingRepository;
            _shippingBusinessRules = shippingBusinessRules;
        }

        public async Task<UpdatedShippingResponse> Handle(UpdateShippingCommand request, CancellationToken cancellationToken)
        {
            Shipping? shipping = await _shippingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shippingBusinessRules.ShippingShouldExistWhenSelected(shipping);
            shipping = _mapper.Map(request, shipping);

            await _shippingRepository.UpdateAsync(shipping!);

            UpdatedShippingResponse response = _mapper.Map<UpdatedShippingResponse>(shipping);
            return response;
        }
    }
}