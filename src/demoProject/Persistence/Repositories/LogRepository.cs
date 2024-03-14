using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LogRepository : EfRepositoryBase<Log, int, BaseDbContext>, ILogRepository
{
    public LogRepository(BaseDbContext context) : base(context)
    {
    }
}