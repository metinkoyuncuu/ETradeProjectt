using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShippingRepository : EfRepositoryBase<Shipping, int, BaseDbContext>, IShippingRepository
{
    public ShippingRepository(BaseDbContext context) : base(context)
    {
    }
}