using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderProductRepository : IAsyncRepository<OrderProduct, int>, IRepository<OrderProduct, int>
{
}