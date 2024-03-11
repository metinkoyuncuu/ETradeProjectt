using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductQuestions;

public interface IProductQuestionsService
{
    Task<ProductQuestion?> GetAsync(
        Expression<Func<ProductQuestion, bool>> predicate,
        Func<IQueryable<ProductQuestion>, IIncludableQueryable<ProductQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductQuestion>?> GetListAsync(
        Expression<Func<ProductQuestion, bool>>? predicate = null,
        Func<IQueryable<ProductQuestion>, IOrderedQueryable<ProductQuestion>>? orderBy = null,
        Func<IQueryable<ProductQuestion>, IIncludableQueryable<ProductQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductQuestion> AddAsync(ProductQuestion productQuestion);
    Task<ProductQuestion> UpdateAsync(ProductQuestion productQuestion);
    Task<ProductQuestion> DeleteAsync(ProductQuestion productQuestion, bool permanent = false);
}
