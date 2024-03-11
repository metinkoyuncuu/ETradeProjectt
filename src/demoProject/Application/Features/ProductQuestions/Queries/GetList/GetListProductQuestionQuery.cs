using Application.Features.ProductQuestions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductQuestions.Constants.ProductQuestionsOperationClaims;

namespace Application.Features.ProductQuestions.Queries.GetList;

public class GetListProductQuestionQuery : IRequest<GetListResponse<GetListProductQuestionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductQuestions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductQuestions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductQuestionQueryHandler : IRequestHandler<GetListProductQuestionQuery, GetListResponse<GetListProductQuestionListItemDto>>
    {
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly IMapper _mapper;

        public GetListProductQuestionQueryHandler(IProductQuestionRepository productQuestionRepository, IMapper mapper)
        {
            _productQuestionRepository = productQuestionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductQuestionListItemDto>> Handle(GetListProductQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductQuestion> productQuestions = await _productQuestionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductQuestionListItemDto> response = _mapper.Map<GetListResponse<GetListProductQuestionListItemDto>>(productQuestions);
            return response;
        }
    }
}