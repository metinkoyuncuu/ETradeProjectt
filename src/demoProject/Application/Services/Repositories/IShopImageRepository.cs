using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShopImageRepository : IAsyncRepository<ShopImage, int>, IRepository<ShopImage, int>
{
}