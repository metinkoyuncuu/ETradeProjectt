using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBillRepository : IAsyncRepository<Bill, int>, IRepository<Bill, int>
{
}