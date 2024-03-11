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

namespace Application.Features.OrderProducts.Commands.Create;

public class CreateOrderProductCommand : IRequest<CreatedOrderProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string Status { get; set; }

    public string[] Roles => new[] { Admin, Write, OrderProductsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrderProducts";

    public class CreateOrderProductCommandHandler : IRequestHandler<CreateOrderProductCommand, CreatedOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public CreateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository,
                                         OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<CreatedOrderProductResponse> Handle(CreateOrderProductCommand request, CancellationToken cancellationToken)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProduct>(request);

            await _orderProductRepository.AddAsync(orderProduct);

            CreatedOrderProductResponse response = _mapper.Map<CreatedOrderProductResponse>(orderProduct);
            return response;
        }
    }
}