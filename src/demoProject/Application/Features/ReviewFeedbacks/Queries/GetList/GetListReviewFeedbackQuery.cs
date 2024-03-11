using Application.Features.ReviewFeedbacks.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ReviewFeedbacks.Constants.ReviewFeedbacksOperationClaims;

namespace Application.Features.ReviewFeedbacks.Queries.GetList;

public class GetListReviewFeedbackQuery : IRequest<GetListResponse<GetListReviewFeedbackListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListReviewFeedbacks({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetReviewFeedbacks";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListReviewFeedbackQueryHandler : IRequestHandler<GetListReviewFeedbackQuery, GetListResponse<GetListReviewFeedbackListItemDto>>
    {
        private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
        private readonly IMapper _mapper;

        public GetListReviewFeedbackQueryHandler(IReviewFeedbackRepository reviewFeedbackRepository, IMapper mapper)
        {
            _reviewFeedbackRepository = reviewFeedbackRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListReviewFeedbackListItemDto>> Handle(GetListReviewFeedbackQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ReviewFeedback> reviewFeedbacks = await _reviewFeedbackRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListReviewFeedbackListItemDto> response = _mapper.Map<GetListResponse<GetListReviewFeedbackListItemDto>>(reviewFeedbacks);
            return response;
        }
    }
}