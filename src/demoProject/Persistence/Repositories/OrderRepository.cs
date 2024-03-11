using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderRepository : EfRepositoryBase<Order, int, BaseDbContext>, IOrderRepository
{
    public OrderRepository(BaseDbContext context) : base(context)
    {
    }
}