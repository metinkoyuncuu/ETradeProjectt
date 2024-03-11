using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SizeRepository : EfRepositoryBase<Size, int, BaseDbContext>, ISizeRepository
{
    public SizeRepository(BaseDbContext context) : base(context)
    {
    }
}