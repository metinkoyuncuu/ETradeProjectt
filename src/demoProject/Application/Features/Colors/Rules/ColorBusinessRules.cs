using Application.Features.Colors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules : BaseBusinessRules
{
    private readonly IColorRepository _colorRepository;

    public ColorBusinessRules(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public Task ColorShouldExistWhenSelected(Color? color)
    {
        if (color == null)
            throw new BusinessException(ColorsBusinessMessages.ColorNotExists);
        return Task.CompletedTask;
    }

    public async Task ColorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Color? color = await _colorRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ColorShouldExistWhenSelected(color);
    }
}