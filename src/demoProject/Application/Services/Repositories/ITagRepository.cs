using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITagRepository : IAsyncRepository<Tag, int>, IRepository<Tag, int>
{
}