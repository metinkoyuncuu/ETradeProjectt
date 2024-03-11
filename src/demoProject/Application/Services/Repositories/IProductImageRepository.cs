using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductImageRepository : IAsyncRepository<ProductImage, int>, IRepository<ProductImage, int>
{
}