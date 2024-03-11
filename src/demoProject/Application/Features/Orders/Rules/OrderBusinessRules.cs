using Application.Features.Orders.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Orders.Rules;

public class OrderBusinessRules : BaseBusinessRules
{
    private readonly IOrderRepository _orderRepository;

    public OrderBusinessRules(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task OrderShouldExistWhenSelected(Order? order)
    {
        if (order == null)
            throw new BusinessException(OrdersBusinessMessages.OrderNotExists);
        return Task.CompletedTask;
    }

    public async Task OrderIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderShouldExistWhenSelected(order);
    }
}