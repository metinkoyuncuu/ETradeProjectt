using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICouponRepository : IAsyncRepository<Coupon, int>, IRepository<Coupon, int>
{
}