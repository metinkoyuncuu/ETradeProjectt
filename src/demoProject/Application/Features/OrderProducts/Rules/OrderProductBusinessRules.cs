using Application.Features.OrderProducts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.OrderProducts.Rules;

public class OrderProductBusinessRules : BaseBusinessRules
{
    private readonly IOrderProductRepository _orderProductRepository;

    public OrderProductBusinessRules(IOrderProductRepository orderProductRepository)
    {
        _orderProductRepository = orderProductRepository;
    }

    public Task OrderProductShouldExistWhenSelected(OrderProduct? orderProduct)
    {
        if (orderProduct == null)
            throw new BusinessException(OrderProductsBusinessMessages.OrderProductNotExists);
        return Task.CompletedTask;
    }

    public async Task OrderProductIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        OrderProduct? orderProduct = await _orderProductRepository.GetAsync(
            predicate: op => op.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderProductShouldExistWhenSelected(orderProduct);
    }
}