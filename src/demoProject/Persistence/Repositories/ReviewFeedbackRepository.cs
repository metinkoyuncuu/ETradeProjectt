using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ReviewFeedbackRepository : EfRepositoryBase<ReviewFeedback, int, BaseDbContext>, IReviewFeedbackRepository
{
    public ReviewFeedbackRepository(BaseDbContext context) : base(context)
    {
    }
}