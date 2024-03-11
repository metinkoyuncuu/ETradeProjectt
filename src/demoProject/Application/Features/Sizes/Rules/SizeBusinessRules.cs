using Application.Features.Sizes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Sizes.Rules;

public class SizeBusinessRules : BaseBusinessRules
{
    private readonly ISizeRepository _sizeRepository;

    public SizeBusinessRules(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public Task SizeShouldExistWhenSelected(Size? size)
    {
        if (size == null)
            throw new BusinessException(SizesBusinessMessages.SizeNotExists);
        return Task.CompletedTask;
    }

    public async Task SizeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Size? size = await _sizeRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SizeShouldExistWhenSelected(size);
    }
}