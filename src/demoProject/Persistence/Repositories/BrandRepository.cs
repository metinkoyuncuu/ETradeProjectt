using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Expressions;
using Core.Persistence.Paging;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, int, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {
    }
}