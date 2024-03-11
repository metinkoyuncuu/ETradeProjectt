using Application.Features.CustomerCoupons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCoupons;

public class CustomerCouponsManager : ICustomerCouponsService
{
    private readonly ICustomerCouponRepository _customerCouponRepository;
    private readonly CustomerCouponBusinessRules _customerCouponBusinessRules;

    public CustomerCouponsManager(ICustomerCouponRepository customerCouponRepository, CustomerCouponBusinessRules customerCouponBusinessRules)
    {
        _customerCouponRepository = customerCouponRepository;
        _customerCouponBusinessRules = customerCouponBusinessRules;
    }

    public async Task<CustomerCoupon?> GetAsync(
        Expression<Func<CustomerCoupon, bool>> predicate,
        Func<IQueryable<CustomerCoupon>, IIncludableQueryable<CustomerCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCoupon? customerCoupon = await _customerCouponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCoupon;
    }

    public async Task<IPaginate<CustomerCoupon>?> GetListAsync(
        Expression<Func<CustomerCoupon, bool>>? predicate = null,
        Func<IQueryable<CustomerCoupon>, IOrderedQueryable<CustomerCoupon>>? orderBy = null,
        Func<IQueryable<CustomerCoupon>, IIncludableQueryable<CustomerCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCoupon> customerCouponList = await _customerCouponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCouponList;
    }

    public async Task<CustomerCoupon> AddAsync(CustomerCoupon customerCoupon)
    {
        CustomerCoupon addedCustomerCoupon = await _customerCouponRepository.AddAsync(customerCoupon);

        return addedCustomerCoupon;
    }

    public async Task<CustomerCoupon> UpdateAsync(CustomerCoupon customerCoupon)
    {
        CustomerCoupon updatedCustomerCoupon = await _customerCouponRepository.UpdateAsync(customerCoupon);

        return updatedCustomerCoupon;
    }

    public async Task<CustomerCoupon> DeleteAsync(CustomerCoupon customerCoupon, bool permanent = false)
    {
        CustomerCoupon deletedCustomerCoupon = await _customerCouponRepository.DeleteAsync(customerCoupon);

        return deletedCustomerCoupon;
    }
}
