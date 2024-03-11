using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShopImageRepository : EfRepositoryBase<ShopImage, int, BaseDbContext>, IShopImageRepository
{
    public ShopImageRepository(BaseDbContext context) : base(context)
    {
    }
}