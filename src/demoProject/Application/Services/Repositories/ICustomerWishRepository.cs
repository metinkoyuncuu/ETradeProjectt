using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerWishRepository : IAsyncRepository<CustomerWish, int>, IRepository<CustomerWish, int>
{
}