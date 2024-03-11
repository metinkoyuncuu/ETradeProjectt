using Application.Features.OrderProducts.Constants;
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

namespace Application.Features.OrderProducts.Commands.Delete;

public class DeleteOrderProductCommand : IRequest<DeletedOrderProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, OrderProductsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrderProducts";

    public class DeleteOrderProductCommandHandler : IRequestHandler<DeleteOrderProductCommand, DeletedOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public DeleteOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository,
                                         OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<DeletedOrderProductResponse> Handle(DeleteOrderProductCommand request, CancellationToken cancellationToken)
        {
            OrderProduct? orderProduct = await _orderProductRepository.GetAsync(predicate: op => op.Id == request.Id, cancellationToken: cancellationToken);
            await _orderProductBusinessRules.OrderProductShouldExistWhenSelected(orderProduct);

            await _orderProductRepository.DeleteAsync(orderProduct!);

            DeletedOrderProductResponse response = _mapper.Map<DeletedOrderProductResponse>(orderProduct);
            return response;
        }
    }
}