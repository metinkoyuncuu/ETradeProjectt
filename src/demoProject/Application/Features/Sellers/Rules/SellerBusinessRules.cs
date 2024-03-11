using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Sellers.Rules;

public class SellerBusinessRules : BaseBusinessRules
{
    private readonly ISellerRepository _sellerRepository;

    public SellerBusinessRules(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public Task SellerShouldExistWhenSelected(Seller? seller)
    {
        if (seller == null)
            throw new BusinessException(SellersBusinessMessages.SellerNotExists);
        return Task.CompletedTask;
    }

    public async Task SellerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Seller? seller = await _sellerRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SellerShouldExistWhenSelected(seller);
    }
}