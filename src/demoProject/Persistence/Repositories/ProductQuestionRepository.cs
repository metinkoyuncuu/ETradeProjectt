using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductQuestionRepository : EfRepositoryBase<ProductQuestion, int, BaseDbContext>, IProductQuestionRepository
{
    public ProductQuestionRepository(BaseDbContext context) : base(context)
    {
    }
}