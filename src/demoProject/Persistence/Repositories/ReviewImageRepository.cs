using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ReviewImageRepository : EfRepositoryBase<ReviewImage, int, BaseDbContext>, IReviewImageRepository
{
    public ReviewImageRepository(BaseDbContext context) : base(context)
    {
    }
}