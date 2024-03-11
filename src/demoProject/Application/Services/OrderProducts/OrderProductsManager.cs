using Application.Features.OrderProducts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderProducts;

public class OrderProductsManager : IOrderProductsService
{
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly OrderProductBusinessRules _orderProductBusinessRules;

    public OrderProductsManager(IOrderProductRepository orderProductRepository, OrderProductBusinessRules orderProductBusinessRules)
    {
        _orderProductRepository = orderProductRepository;
        _orderProductBusinessRules = orderProductBusinessRules;
    }

    public async Task<OrderProduct?> GetAsync(
        Expression<Func<OrderProduct, bool>> predicate,
        Func<IQueryable<OrderProduct>, IIncludableQueryable<OrderProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderProduct? orderProduct = await _orderProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderProduct;
    }

    public async Task<IPaginate<OrderProduct>?> GetListAsync(
        Expression<Func<OrderProduct, bool>>? predicate = null,
        Func<IQueryable<OrderProduct>, IOrderedQueryable<OrderProduct>>? orderBy = null,
        Func<IQueryable<OrderProduct>, IIncludableQueryable<OrderProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderProduct> orderProductList = await _orderProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderProductList;
    }

    public async Task<OrderProduct> AddAsync(OrderProduct orderProduct)
    {
        OrderProduct addedOrderProduct = await _orderProductRepository.AddAsync(orderProduct);

        return addedOrderProduct;
    }

    public async Task<OrderProduct> UpdateAsync(OrderProduct orderProduct)
    {
        OrderProduct updatedOrderProduct = await _orderProductRepository.UpdateAsync(orderProduct);

        return updatedOrderProduct;
    }

    public async Task<OrderProduct> DeleteAsync(OrderProduct orderProduct, bool permanent = false)
    {
        OrderProduct deletedOrderProduct = await _orderProductRepository.DeleteAsync(orderProduct);

        return deletedOrderProduct;
    }
}
