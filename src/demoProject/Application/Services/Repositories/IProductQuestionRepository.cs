using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductQuestionRepository : IAsyncRepository<ProductQuestion, int>, IRepository<ProductQuestion, int>
{
}