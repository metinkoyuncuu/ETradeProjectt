using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CouponRepository : EfRepositoryBase<Coupon, int, BaseDbContext>, ICouponRepository
{
    public CouponRepository(BaseDbContext context) : base(context)
    {
    }
}