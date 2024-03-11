using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCreditCards;

public interface ICustomerCreditCardsService
{
    Task<CustomerCreditCard?> GetAsync(
        Expression<Func<CustomerCreditCard, bool>> predicate,
        Func<IQueryable<CustomerCreditCard>, IIncludableQueryable<CustomerCreditCard, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerCreditCard>?> GetListAsync(
        Expression<Func<CustomerCreditCard, bool>>? predicate = null,
        Func<IQueryable<CustomerCreditCard>, IOrderedQueryable<CustomerCreditCard>>? orderBy = null,
        Func<IQueryable<CustomerCreditCard>, IIncludableQueryable<CustomerCreditCard, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerCreditCard> AddAsync(CustomerCreditCard customerCreditCard);
    Task<CustomerCreditCard> UpdateAsync(CustomerCreditCard customerCreditCard);
    Task<CustomerCreditCard> DeleteAsync(CustomerCreditCard customerCreditCard, bool permanent = false);
}
