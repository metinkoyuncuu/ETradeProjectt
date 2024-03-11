using Application.Features.OrderProducts.Constants;
using Application.Features.OrderProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrderProducts.Constants.OrderProductsOperationClaims;

namespace Application.Features.OrderProducts.Commands.Update;

public class UpdateOrderProductCommand : IRequest<UpdatedOrderProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }

    public string[] Roles => new[] { Admin, Write, OrderProductsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrderProducts";

    public class UpdateOrderProductCommandHandler : IRequestHandler<UpdateOrderProductCommand, UpdatedOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public UpdateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository,
                                         OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<UpdatedOrderProductResponse> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
        {
            OrderProduct? orderProduct = await _orderProductRepository.GetAsync(predicate: op => op.Id == request.Id, cancellationToken: cancellationToken);
            await _orderProductBusinessRules.OrderProductShouldExistWhenSelected(orderProduct);
            orderProduct = _mapper.Map(request, orderProduct);

            await _orderProductRepository.UpdateAsync(orderProduct!);

            UpdatedOrderProductResponse response = _mapper.Map<UpdatedOrderProductResponse>(orderProduct);
            return response;
        }
    }
}