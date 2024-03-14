
using Application.Features.Auth.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Customers;
using Application.Services.Sellers;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Extensions;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ContextOperations;
public class ContextOperationsManager : IContextOperationsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISellersService _sellersService;
    private readonly ICustomersService _customersService;
    private readonly int _userId;

    public ContextOperationsManager(IHttpContextAccessor httpContextAccessor, ISellersService sellersService, ICustomersService customersService)
    {
        _httpContextAccessor = httpContextAccessor;
        _sellersService = sellersService;
        _customersService = customersService;

        _userId = _httpContextAccessor.HttpContext.User.GetUserId();
    }

    public async Task<Customer> GetCustomerFromContext() 
    {
        Customer? customer = await _customersService.GetAsync(predicate: s => s.UserId == _userId) ;

        return customer ?? throw new AuthorizationException("You are not a Customer. Redirect to Customer login page...");
    }
    public async Task<Seller> GetSellerFromContext() 
    {
        Seller? seller = await _sellersService.GetAsync(predicate:s=>s.UserId== _userId);

        return seller ?? throw new AuthorizationException("You are not a Seller. Redirect to Seller login page...");
    }

    public List<string>? GetOperationClaims() => _httpContextAccessor.HttpContext.User.ClaimRoles();
    
}

