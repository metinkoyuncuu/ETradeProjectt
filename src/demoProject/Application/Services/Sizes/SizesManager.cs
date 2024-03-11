using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sizes;

public class SizesManager : ISizesService
{
    private readonly ISizeRepository _sizeRepository;
    private readonly SizeBusinessRules _sizeBusinessRules;

    public SizesManager(ISizeRepository sizeRepository, SizeBusinessRules sizeBusinessRules)
    {
        _sizeRepository = sizeRepository;
        _sizeBusinessRules = sizeBusinessRules;
    }

    public async Task<Size?> GetAsync(
        Expression<Func<Size, bool>> predicate,
        Func<IQueryable<Size>, IIncludableQueryable<Size, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Size? size = await _sizeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return size;
    }

    public async Task<IPaginate<Size>?> GetListAsync(
        Expression<Func<Size, bool>>? predicate = null,
        Func<IQueryable<Size>, IOrderedQueryable<Size>>? orderBy = null,
        Func<IQueryable<Size>, IIncludableQueryable<Size, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Size> sizeList = await _sizeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sizeList;
    }

    public async Task<Size> AddAsync(Size size)
    {
        Size addedSize = await _sizeRepository.AddAsync(size);

        return addedSize;
    }

    public async Task<Size> UpdateAsync(Size size)
    {
        Size updatedSize = await _sizeRepository.UpdateAsync(size);

        return updatedSize;
    }

    public async Task<Size> DeleteAsync(Size size, bool permanent = false)
    {
        Size deletedSize = await _sizeRepository.DeleteAsync(size);

        return deletedSize;
    }
}
