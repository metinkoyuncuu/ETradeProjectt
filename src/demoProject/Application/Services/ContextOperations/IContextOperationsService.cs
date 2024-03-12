using Domain.Entities;

namespace Application.Services.ContextOperations;
public interface IContextOperationsService
{
    Task<Seller> GetSellerFromContext();
    Task<Customer> GetCustomerFromContext();
}

