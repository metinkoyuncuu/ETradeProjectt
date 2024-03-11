using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISellerRepository : IAsyncRepository<Seller, int>, IRepository<Seller, int>
{
}