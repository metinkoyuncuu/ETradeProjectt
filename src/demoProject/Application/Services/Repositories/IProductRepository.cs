using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>, IRepository<Product, int>
{
}