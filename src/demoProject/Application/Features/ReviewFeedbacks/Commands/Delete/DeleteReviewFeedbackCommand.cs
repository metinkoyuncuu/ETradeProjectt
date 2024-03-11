using Application.Features.ReviewFeedbacks.Constants;
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

namespace Application.Features.ReviewFeedbacks.Commands.Delete;

public class DeleteReviewFeedbackCommand : IRequest<DeletedReviewFeedbackResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewFeedbacksOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewFeedbacks";

    public class DeleteReviewFeedbackCommandHandler : IRequestHandler<DeleteReviewFeedbackCommand, DeletedReviewFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
        private readonly ReviewFeedbackBusinessRules _reviewFeedbackBusinessRules;

        public DeleteReviewFeedbackCommandHandler(IMapper mapper, IReviewFeedbackRepository reviewFeedbackRepository,
                                         ReviewFeedbackBusinessRules reviewFeedbackBusinessRules)
        {
            _mapper = mapper;
            _reviewFeedbackRepository = reviewFeedbackRepository;
            _reviewFeedbackBusinessRules = reviewFeedbackBusinessRules;
        }

        public async Task<DeletedReviewFeedbackResponse> Handle(DeleteReviewFeedbackCommand request, CancellationToken cancellationToken)
        {
            ReviewFeedback? reviewFeedback = await _reviewFeedbackRepository.GetAsync(predicate: rf => rf.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewFeedbackBusinessRules.ReviewFeedbackShouldExistWhenSelected(reviewFeedback);

            await _reviewFeedbackRepository.DeleteAsync(reviewFeedback!);

            DeletedReviewFeedbackResponse response = _mapper.Map<DeletedReviewFeedbackResponse>(reviewFeedback);
            return response;
        }
    }
}