using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TermConditionRepository : EfRepositoryBase<TermCondition, int, BaseDbContext>, ITermConditionRepository
{
    public TermConditionRepository(BaseDbContext context) : base(context)
    {
    }
}