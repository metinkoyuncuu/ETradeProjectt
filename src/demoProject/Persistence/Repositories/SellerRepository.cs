using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SellerRepository : EfRepositoryBase<Seller, int, BaseDbContext>, ISellerRepository
{
    public SellerRepository(BaseDbContext context) : base(context)
    {
    }
}