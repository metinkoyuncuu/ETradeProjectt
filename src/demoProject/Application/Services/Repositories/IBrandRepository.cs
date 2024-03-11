using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand, int>, IRepository<Brand, int>
{
}