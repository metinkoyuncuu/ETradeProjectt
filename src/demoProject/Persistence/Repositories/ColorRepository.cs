using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ColorRepository : EfRepositoryBase<Color, int, BaseDbContext>, IColorRepository
{
    public ColorRepository(BaseDbContext context) : base(context)
    {
    }
}