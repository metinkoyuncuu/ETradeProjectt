using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IReviewImageRepository : IAsyncRepository<ReviewImage, int>, IRepository<ReviewImage, int>
{
}