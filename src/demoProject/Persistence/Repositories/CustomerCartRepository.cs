using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCartRepository : EfRepositoryBase<CustomerCart, int, BaseDbContext>, ICustomerCartRepository
{
    public CustomerCartRepository(BaseDbContext context) : base(context)
    {
    }
}