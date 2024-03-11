using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerWishRepository : EfRepositoryBase<CustomerWish, int, BaseDbContext>, ICustomerWishRepository
{
    public CustomerWishRepository(BaseDbContext context) : base(context)
    {
    }
}