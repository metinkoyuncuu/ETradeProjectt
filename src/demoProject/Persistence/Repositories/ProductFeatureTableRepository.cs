using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductFeatureTableRepository : EfRepositoryBase<ProductFeatureTable, int, BaseDbContext>, IProductFeatureTableRepository
{
    public ProductFeatureTableRepository(BaseDbContext context) : base(context)
    {
    }
}