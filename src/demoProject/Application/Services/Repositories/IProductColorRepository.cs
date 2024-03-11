using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductColorRepository : IAsyncRepository<ProductColor, int>, IRepository<ProductColor, int>
{
}