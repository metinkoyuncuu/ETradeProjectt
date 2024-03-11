using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductTagRepository : IAsyncRepository<ProductTag, int>, IRepository<ProductTag, int>
{
}