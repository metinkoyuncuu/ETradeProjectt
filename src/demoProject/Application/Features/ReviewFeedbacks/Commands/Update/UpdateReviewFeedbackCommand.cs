using Application.Features.ReviewFeedbacks.Constants;
using Application.Features.ReviewFeedbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ReviewFeedbacks.Constants.ReviewFeedbacksOperationClaims;

namespace Application.Features.ReviewFeedbacks.Commands.Update;

public class UpdateReviewFeedbackCommand : IRequest<UpdatedReviewFeedbackResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewFeedbacksOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewFeedbacks";

    public class UpdateReviewFeedbackCommandHandler : IRequestHandler<UpdateReviewFeedbackCommand, UpdatedReviewFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
        private readonly ReviewFeedbackBusinessRules _reviewFeedbackBusinessRules;

        public UpdateReviewFeedbackCommandHandler(IMapper mapper, IReviewFeedbackRepository reviewFeedbackRepository,
                                         ReviewFeedbackBusinessRules reviewFeedbackBusinessRules)
        {
            _mapper = mapper;
            _reviewFeedbackRepository = reviewFeedbackRepository;
            _reviewFeedbackBusinessRules = reviewFeedbackBusinessRules;
        }

        public async Task<UpdatedReviewFeedbackResponse> Handle(UpdateReviewFeedbackCommand request, CancellationToken cancellationToken)
        {
            ReviewFeedback? reviewFeedback = await _reviewFeedbackRepository.GetAsync(predicate: rf => rf.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewFeedbackBusinessRules.ReviewFeedbackShouldExistWhenSelected(reviewFeedback);
            reviewFeedback = _mapper.Map(request, reviewFeedback);

            await _reviewFeedbackRepository.UpdateAsync(reviewFeedback!);

            UpdatedReviewFeedbackResponse response = _mapper.Map<UpdatedReviewFeedbackResponse>(reviewFeedback);
            return response;
        }
    }
}