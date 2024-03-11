using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShopSellerRepository : IAsyncRepository<ShopSeller, int>, IRepository<ShopSeller, int>
{
}