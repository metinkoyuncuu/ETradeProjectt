using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISubCategoryRepository : IAsyncRepository<SubCategory, int>, IRepository<SubCategory, int>
{
}