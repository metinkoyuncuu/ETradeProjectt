using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILogRepository : IAsyncRepository<Log, int>, IRepository<Log, int>
{
}