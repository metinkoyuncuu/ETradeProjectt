using Application.Features.Faqs.Constants;
using Application.Features.Faqs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Faqs.Constants.FaqsOperationClaims;

namespace Application.Features.Faqs.Queries.GetById;

public class GetByIdFaqQuery : IRequest<GetByIdFaqResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdFaqQueryHandler : IRequestHandler<GetByIdFaqQuery, GetByIdFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        private readonly FaqBusinessRules _faqBusinessRules;

        public GetByIdFaqQueryHandler(IMapper mapper, IFaqRepository faqRepository, FaqBusinessRules faqBusinessRules)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _faqBusinessRules = faqBusinessRules;
        }

        public async Task<GetByIdFaqResponse> Handle(GetByIdFaqQuery request, CancellationToken cancellationToken)
        {
            Faq? faq = await _faqRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _faqBusinessRules.FaqShouldExistWhenSelected(faq);

            GetByIdFaqResponse response = _mapper.Map<GetByIdFaqResponse>(faq);
            return response;
        }
    }
}