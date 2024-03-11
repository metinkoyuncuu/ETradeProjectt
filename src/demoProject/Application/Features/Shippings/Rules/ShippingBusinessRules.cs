using Application.Features.Shippings.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Shippings.Rules;

public class ShippingBusinessRules : BaseBusinessRules
{
    private readonly IShippingRepository _shippingRepository;

    public ShippingBusinessRules(IShippingRepository shippingRepository)
    {
        _shippingRepository = shippingRepository;
    }

    public Task ShippingShouldExistWhenSelected(Shipping? shipping)
    {
        if (shipping == null)
            throw new BusinessException(ShippingsBusinessMessages.ShippingNotExists);
        return Task.CompletedTask;
    }

    public async Task ShippingIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Shipping? shipping = await _shippingRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShippingShouldExistWhenSelected(shipping);
    }
}