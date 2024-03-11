using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderProductRepository : EfRepositoryBase<OrderProduct, int, BaseDbContext>, IOrderProductRepository
{
    public OrderProductRepository(BaseDbContext context) : base(context)
    {
    }
}