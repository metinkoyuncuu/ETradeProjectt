using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductColorRepository : EfRepositoryBase<ProductColor, int, BaseDbContext>, IProductColorRepository
{
    public ProductColorRepository(BaseDbContext context) : base(context)
    {
    }
}