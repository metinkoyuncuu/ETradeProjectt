using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerCreditCardRepository : IAsyncRepository<CustomerCreditCard, int>, IRepository<CustomerCreditCard, int>
{
}