using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductReviewRepository : EfRepositoryBase<ProductReview, int, BaseDbContext>, IProductReviewRepository
{
    public ProductReviewRepository(BaseDbContext context) : base(context)
    {
    }
}