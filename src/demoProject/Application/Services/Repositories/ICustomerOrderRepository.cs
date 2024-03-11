using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerOrderRepository : IAsyncRepository<CustomerOrder, int>, IRepository<CustomerOrder, int>
{
}