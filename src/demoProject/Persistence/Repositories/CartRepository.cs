using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CartRepository : EfRepositoryBase<Cart, int, BaseDbContext>, ICartRepository
{
    public CartRepository(BaseDbContext context) : base(context)
    {
    }
}