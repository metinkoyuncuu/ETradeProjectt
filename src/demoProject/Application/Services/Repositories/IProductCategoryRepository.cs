using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductCategoryRepository : IAsyncRepository<ProductCategory, int>, IRepository<ProductCategory, int>
{
}