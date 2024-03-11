using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShopProductRepository : EfRepositoryBase<ShopProduct, int, BaseDbContext>, IShopProductRepository
{
    public ShopProductRepository(BaseDbContext context) : base(context)
    {
    }
}