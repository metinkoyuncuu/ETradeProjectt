using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductSizeRepository : EfRepositoryBase<ProductSize, int, BaseDbContext>, IProductSizeRepository
{
    public ProductSizeRepository(BaseDbContext context) : base(context)
    {
    }
}