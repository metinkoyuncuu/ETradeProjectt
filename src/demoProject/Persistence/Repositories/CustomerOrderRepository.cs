using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerOrderRepository : EfRepositoryBase<CustomerOrder, int, BaseDbContext>, ICustomerOrderRepository
{
    public CustomerOrderRepository(BaseDbContext context) : base(context)
    {
    }
}