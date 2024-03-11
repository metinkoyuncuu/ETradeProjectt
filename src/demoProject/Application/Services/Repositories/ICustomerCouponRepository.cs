using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerCouponRepository : IAsyncRepository<CustomerCoupon, int>, IRepository<CustomerCoupon, int>
{
}