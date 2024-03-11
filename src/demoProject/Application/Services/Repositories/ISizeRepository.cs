using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISizeRepository : IAsyncRepository<Size, int>, IRepository<Size, int>
{
}