using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductVariantRepository : EfRepositoryBase<ProductVariant, int, BaseDbContext>, IProductVariantRepository
{
    public ProductVariantRepository(BaseDbContext context) : base(context)
    {
    }
}