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

namespace Application.Features.Faqs.Commands.Create;

public class CreateFaqCommand : IRequest<CreatedFaqResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Question { get; set; }
    public string Answer { get; set; }

    public string[] Roles => new[] { Admin, Write, FaqsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetFaqs";

    public class CreateFaqCommandHandler : IRequestHandler<CreateFaqCommand, CreatedFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        private readonly FaqBusinessRules _faqBusinessRules;

        public CreateFaqCommandHandler(IMapper mapper, IFaqRepository faqRepository,
                                         FaqBusinessRules faqBusinessRules)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _faqBusinessRules = faqBusinessRules;
        }

        public async Task<CreatedFaqResponse> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            Faq faq = _mapper.Map<Faq>(request);

            await _faqRepository.AddAsync(faq);

            CreatedFaqResponse response = _mapper.Map<CreatedFaqResponse>(faq);
            return response;
        }
    }
}