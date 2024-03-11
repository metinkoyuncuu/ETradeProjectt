using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShopCouponRepository : EfRepositoryBase<ShopCoupon, int, BaseDbContext>, IShopCouponRepository
{
    public ShopCouponRepository(BaseDbContext context) : base(context)
    {
    }
}