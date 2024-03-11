using Application.Features.ReviewFeedbacks.Constants;
using Application.Features.ReviewFeedbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ReviewFeedbacks.Constants.ReviewFeedbacksOperationClaims;

namespace Application.Features.ReviewFeedbacks.Queries.GetById;

public class GetByIdReviewFeedbackQuery : IRequest<GetByIdReviewFeedbackResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdReviewFeedbackQueryHandler : IRequestHandler<GetByIdReviewFeedbackQuery, GetByIdReviewFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
        private readonly ReviewFeedbackBusinessRules _reviewFeedbackBusinessRules;

        public GetByIdReviewFeedbackQueryHandler(IMapper mapper, IReviewFeedbackRepository reviewFeedbackRepository, ReviewFeedbackBusinessRules reviewFeedbackBusinessRules)
        {
            _mapper = mapper;
            _reviewFeedbackRepository = reviewFeedbackRepository;
            _reviewFeedbackBusinessRules = reviewFeedbackBusinessRules;
        }

        public async Task<GetByIdReviewFeedbackResponse> Handle(GetByIdReviewFeedbackQuery request, CancellationToken cancellationToken)
        {
            ReviewFeedback? reviewFeedback = await _reviewFeedbackRepository.GetAsync(predicate: rf => rf.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewFeedbackBusinessRules.ReviewFeedbackShouldExistWhenSelected(reviewFeedback);

            GetByIdReviewFeedbackResponse response = _mapper.Map<GetByIdReviewFeedbackResponse>(reviewFeedback);
            return response;
        }
    }
}