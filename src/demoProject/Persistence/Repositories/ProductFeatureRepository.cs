using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductFeatureRepository : EfRepositoryBase<ProductFeature, int, BaseDbContext>, IProductFeatureRepository
{
    public ProductFeatureRepository(BaseDbContext context) : base(context)
    {
    }
}