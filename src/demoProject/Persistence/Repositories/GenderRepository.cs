using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenderRepository : EfRepositoryBase<Gender, int, BaseDbContext>, IGenderRepository
{
    public GenderRepository(BaseDbContext context) : base(context)
    {
    }
}