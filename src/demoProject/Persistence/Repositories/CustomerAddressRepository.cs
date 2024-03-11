using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerAddressRepository : EfRepositoryBase<CustomerAddress, int, BaseDbContext>, ICustomerAddressRepository
{
    public CustomerAddressRepository(BaseDbContext context) : base(context)
    {
    }
}