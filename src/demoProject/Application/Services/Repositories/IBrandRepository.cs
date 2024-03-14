using Domain.Entities;
using Core.Persistence.Repositories;
using System.Linq.Expressions;
using Core.Persistence.Paging;

namespace Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand, int>, IRepository<Brand, int>
{
}