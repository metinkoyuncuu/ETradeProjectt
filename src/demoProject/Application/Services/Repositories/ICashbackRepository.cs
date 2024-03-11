using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICashbackRepository : IAsyncRepository<Cashback, int>, IRepository<Cashback, int>
{
}