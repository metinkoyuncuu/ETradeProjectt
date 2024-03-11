using Application.Features.Shippings.Constants;
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

namespace Application.Features.Shippings.Commands.Delete;

public class DeleteShippingCommand : IRequest<DeletedShippingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShippingsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippings";

    public class DeleteShippingCommandHandler : IRequestHandler<DeleteShippingCommand, DeletedShippingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShippingRepository _shippingRepository;
        private readonly ShippingBusinessRules _shippingBusinessRules;

        public DeleteShippingCommandHandler(IMapper mapper, IShippingRepository shippingRepository,
                                         ShippingBusinessRules shippingBusinessRules)
        {
            _mapper = mapper;
            _shippingRepository = shippingRepository;
            _shippingBusinessRules = shippingBusinessRules;
        }

        public async Task<DeletedShippingResponse> Handle(DeleteShippingCommand request, CancellationToken cancellationToken)
        {
            Shipping? shipping = await _shippingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shippingBusinessRules.ShippingShouldExistWhenSelected(shipping);

            await _shippingRepository.DeleteAsync(shipping!);

            DeletedShippingResponse response = _mapper.Map<DeletedShippingResponse>(shipping);
            return response;
        }
    }
}