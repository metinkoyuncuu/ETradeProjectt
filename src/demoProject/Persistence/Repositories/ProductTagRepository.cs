using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductTagRepository : EfRepositoryBase<ProductTag, int, BaseDbContext>, IProductTagRepository
{
    public ProductTagRepository(BaseDbContext context) : base(context)
    {
    }
}