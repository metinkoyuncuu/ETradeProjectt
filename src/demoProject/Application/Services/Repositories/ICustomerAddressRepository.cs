using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerAddressRepository : IAsyncRepository<CustomerAddress, int>, IRepository<CustomerAddress, int>
{
}