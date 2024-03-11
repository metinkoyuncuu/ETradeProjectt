using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sellers;

public class SellersManager : ISellersService
{
    private readonly ISellerRepository _sellerRepository;
    private readonly SellerBusinessRules _sellerBusinessRules;

    public SellersManager(ISellerRepository sellerRepository, SellerBusinessRules sellerBusinessRules)
    {
        _sellerRepository = sellerRepository;
        _sellerBusinessRules = sellerBusinessRules;
    }

    public async Task<Seller?> GetAsync(
        Expression<Func<Seller, bool>> predicate,
        Func<IQueryable<Seller>, IIncludableQueryable<Seller, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Seller? seller = await _sellerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return seller;
    }

    public async Task<IPaginate<Seller>?> GetListAsync(
        Expression<Func<Seller, bool>>? predicate = null,
        Func<IQueryable<Seller>, IOrderedQueryable<Seller>>? orderBy = null,
        Func<IQueryable<Seller>, IIncludableQueryable<Seller, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Seller> sellerList = await _sellerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sellerList;
    }

    public async Task<Seller> AddAsync(Seller seller)
    {
        Seller addedSeller = await _sellerRepository.AddAsync(seller);

        return addedSeller;
    }

    public async Task<Seller> UpdateAsync(Seller seller)
    {
        Seller updatedSeller = await _sellerRepository.UpdateAsync(seller);

        return updatedSeller;
    }

    public async Task<Seller> DeleteAsync(Seller seller, bool permanent = false)
    {
        Seller deletedSeller = await _sellerRepository.DeleteAsync(seller);

        return deletedSeller;
    }
}
