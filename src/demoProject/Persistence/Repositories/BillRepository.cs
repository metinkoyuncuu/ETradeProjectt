using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BillRepository : EfRepositoryBase<Bill, int, BaseDbContext>, IBillRepository
{
    public BillRepository(BaseDbContext context) : base(context)
    {
    }
}