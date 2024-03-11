using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCouponRepository : EfRepositoryBase<CustomerCoupon, int, BaseDbContext>, ICustomerCouponRepository
{
    public CustomerCouponRepository(BaseDbContext context) : base(context)
    {
    }
}