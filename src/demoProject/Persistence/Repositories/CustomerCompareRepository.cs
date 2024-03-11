using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCompareRepository : EfRepositoryBase<CustomerCompare, int, BaseDbContext>, ICustomerCompareRepository
{
    public CustomerCompareRepository(BaseDbContext context) : base(context)
    {
    }
}