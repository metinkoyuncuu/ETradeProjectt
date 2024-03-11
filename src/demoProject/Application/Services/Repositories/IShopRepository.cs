using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShopRepository : IAsyncRepository<Shop, int>, IRepository<Shop, int>
{
}