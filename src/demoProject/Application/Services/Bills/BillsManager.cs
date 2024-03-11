using Application.Features.Bills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Bills;

public class BillsManager : IBillsService
{
    private readonly IBillRepository _billRepository;
    private readonly BillBusinessRules _billBusinessRules;

    public BillsManager(IBillRepository billRepository, BillBusinessRules billBusinessRules)
    {
        _billRepository = billRepository;
        _billBusinessRules = billBusinessRules;
    }

    public async Task<Bill?> GetAsync(
        Expression<Func<Bill, bool>> predicate,
        Func<IQueryable<Bill>, IIncludableQueryable<Bill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Bill? bill = await _billRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bill;
    }

    public async Task<IPaginate<Bill>?> GetListAsync(
        Expression<Func<Bill, bool>>? predicate = null,
        Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
        Func<IQueryable<Bill>, IIncludableQueryable<Bill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Bill> billList = await _billRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return billList;
    }

    public async Task<Bill> AddAsync(Bill bill)
    {
        Bill addedBill = await _billRepository.AddAsync(bill);

        return addedBill;
    }

    public async Task<Bill> UpdateAsync(Bill bill)
    {
        Bill updatedBill = await _billRepository.UpdateAsync(bill);

        return updatedBill;
    }

    public async Task<Bill> DeleteAsync(Bill bill, bool permanent = false)
    {
        Bill deletedBill = await _billRepository.DeleteAsync(bill);

        return deletedBill;
    }
}
