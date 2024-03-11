using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductCategoryRepository : EfRepositoryBase<ProductCategory, int, BaseDbContext>, IProductCategoryRepository
{
    public ProductCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}