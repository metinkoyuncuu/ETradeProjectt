using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShopSellerRepository : EfRepositoryBase<ShopSeller, int, BaseDbContext>, IShopSellerRepository
{
    public ShopSellerRepository(BaseDbContext context) : base(context)
    {
    }
}