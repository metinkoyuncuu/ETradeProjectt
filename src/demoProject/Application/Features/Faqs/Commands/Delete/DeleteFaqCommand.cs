using Application.Features.Faqs.Constants;
using Application.Features.Faqs.Constants;
using Application.Features.Faqs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Faqs.Constants.FaqsOperationClaims;

namespace Application.Features.Faqs.Commands.Delete;

public class DeleteFaqCommand : IRequest<DeletedFaqResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, FaqsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetFaqs";

    public class DeleteFaqCommandHandler : IRequestHandler<DeleteFaqCommand, DeletedFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        private readonly FaqBusinessRules _faqBusinessRules;

        public DeleteFaqCommandHandler(IMapper mapper, IFaqRepository faqRepository,
                                         FaqBusinessRules faqBusinessRules)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _faqBusinessRules = faqBusinessRules;
        }

        public async Task<DeletedFaqResponse> Handle(DeleteFaqCommand request, CancellationToken cancellationToken)
        {
            Faq? faq = await _faqRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _faqBusinessRules.FaqShouldExistWhenSelected(faq);

            await _faqRepository.DeleteAsync(faq!);

            DeletedFaqResponse response = _mapper.Map<DeletedFaqResponse>(faq);
            return response;
        }
    }
}