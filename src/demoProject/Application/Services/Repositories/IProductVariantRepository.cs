using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductVariantRepository : IAsyncRepository<ProductVariant, int>, IRepository<ProductVariant, int>
{
}