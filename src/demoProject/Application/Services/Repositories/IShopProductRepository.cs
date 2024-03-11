using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShopProductRepository : IAsyncRepository<ShopProduct, int>, IRepository<ShopProduct, int>
{
}