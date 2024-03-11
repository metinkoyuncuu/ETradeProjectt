using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductSizeRepository : IAsyncRepository<ProductSize, int>, IRepository<ProductSize, int>
{
}