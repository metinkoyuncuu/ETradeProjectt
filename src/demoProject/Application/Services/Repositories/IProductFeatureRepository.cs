using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductFeatureRepository : IAsyncRepository<ProductFeature, int>, IRepository<ProductFeature, int>
{
}