using Application.Features.CustomerCoupons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCoupons.Rules;

public class CustomerCouponBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCouponRepository _customerCouponRepository;

    public CustomerCouponBusinessRules(ICustomerCouponRepository customerCouponRepository)
    {
        _customerCouponRepository = customerCouponRepository;
    }

    public Task CustomerCouponShouldExistWhenSelected(CustomerCoupon? customerCoupon)
    {
        if (customerCoupon == null)
            throw new BusinessException(CustomerCouponsBusinessMessages.CustomerCouponNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCouponIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCoupon? customerCoupon = await _customerCouponRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCouponShouldExistWhenSelected(customerCoupon);
    }
}