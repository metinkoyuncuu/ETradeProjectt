using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShippingRepository : IAsyncRepository<Shipping, int>, IRepository<Shipping, int>
{
}