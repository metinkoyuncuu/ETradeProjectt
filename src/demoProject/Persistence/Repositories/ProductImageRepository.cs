using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductImageRepository : EfRepositoryBase<ProductImage, int, BaseDbContext>, IProductImageRepository
{
    public ProductImageRepository(BaseDbContext context) : base(context)
    {
    }
}