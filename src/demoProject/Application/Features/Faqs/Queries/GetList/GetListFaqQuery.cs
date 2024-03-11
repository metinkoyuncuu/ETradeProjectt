using Application.Features.Faqs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Faqs.Constants.FaqsOperationClaims;

namespace Application.Features.Faqs.Queries.GetList;

public class GetListFaqQuery : IRequest<GetListResponse<GetListFaqListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListFaqs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetFaqs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListFaqQueryHandler : IRequestHandler<GetListFaqQuery, GetListResponse<GetListFaqListItemDto>>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;

        public GetListFaqQueryHandler(IFaqRepository faqRepository, IMapper mapper)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFaqListItemDto>> Handle(GetListFaqQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Faq> faqs = await _faqRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFaqListItemDto> response = _mapper.Map<GetListResponse<GetListFaqListItemDto>>(faqs);
            return response;
        }
    }
}