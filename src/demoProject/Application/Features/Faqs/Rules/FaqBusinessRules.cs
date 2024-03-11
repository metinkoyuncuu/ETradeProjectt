using Application.Features.Faqs.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Faqs.Rules;

public class FaqBusinessRules : BaseBusinessRules
{
    private readonly IFaqRepository _faqRepository;

    public FaqBusinessRules(IFaqRepository faqRepository)
    {
        _faqRepository = faqRepository;
    }

    public Task FaqShouldExistWhenSelected(Faq? faq)
    {
        if (faq == null)
            throw new BusinessException(FaqsBusinessMessages.FaqNotExists);
        return Task.CompletedTask;
    }

    public async Task FaqIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Faq? faq = await _faqRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FaqShouldExistWhenSelected(faq);
    }
}