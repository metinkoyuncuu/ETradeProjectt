using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductFeatureTableRepository : IAsyncRepository<ProductFeatureTable, int>, IRepository<ProductFeatureTable, int>
{
}