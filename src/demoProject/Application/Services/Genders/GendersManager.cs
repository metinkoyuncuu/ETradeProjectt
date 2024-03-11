using Application.Features.Genders.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Genders;

public class GendersManager : IGendersService
{
    private readonly IGenderRepository _genderRepository;
    private readonly GenderBusinessRules _genderBusinessRules;

    public GendersManager(IGenderRepository genderRepository, GenderBusinessRules genderBusinessRules)
    {
        _genderRepository = genderRepository;
        _genderBusinessRules = genderBusinessRules;
    }

    public async Task<Gender?> GetAsync(
        Expression<Func<Gender, bool>> predicate,
        Func<IQueryable<Gender>, IIncludableQueryable<Gender, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Gender? gender = await _genderRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return gender;
    }

    public async Task<IPaginate<Gender>?> GetListAsync(
        Expression<Func<Gender, bool>>? predicate = null,
        Func<IQueryable<Gender>, IOrderedQueryable<Gender>>? orderBy = null,
        Func<IQueryable<Gender>, IIncludableQueryable<Gender, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Gender> genderList = await _genderRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return genderList;
    }

    public async Task<Gender> AddAsync(Gender gender)
    {
        Gender addedGender = await _genderRepository.AddAsync(gender);

        return addedGender;
    }

    public async Task<Gender> UpdateAsync(Gender gender)
    {
        Gender updatedGender = await _genderRepository.UpdateAsync(gender);

        return updatedGender;
    }

    public async Task<Gender> DeleteAsync(Gender gender, bool permanent = false)
    {
        Gender deletedGender = await _genderRepository.DeleteAsync(gender);

        return deletedGender;
    }
}
