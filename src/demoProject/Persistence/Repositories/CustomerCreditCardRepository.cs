using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerCreditCardRepository : EfRepositoryBase<CustomerCreditCard, int, BaseDbContext>, ICustomerCreditCardRepository
{
    public CustomerCreditCardRepository(BaseDbContext context) : base(context)
    {
    }
}