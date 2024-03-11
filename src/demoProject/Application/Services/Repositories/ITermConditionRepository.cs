using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITermConditionRepository : IAsyncRepository<TermCondition, int>, IRepository<TermCondition, int>
{
}