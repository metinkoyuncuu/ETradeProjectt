using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IReviewFeedbackRepository : IAsyncRepository<ReviewFeedback, int>, IRepository<ReviewFeedback, int>
{
}