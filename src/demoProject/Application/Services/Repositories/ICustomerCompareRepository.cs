using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerCompareRepository : IAsyncRepository<CustomerCompare, int>, IRepository<CustomerCompare, int>
{
}