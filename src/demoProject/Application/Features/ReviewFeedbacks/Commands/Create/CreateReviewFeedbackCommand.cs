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

namespace Application.Features.ReviewFeedbacks.Commands.Create;

public class CreateReviewFeedbackCommand : IRequest<CreatedReviewFeedbackResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewFeedbacksOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewFeedbacks";

    public class CreateReviewFeedbackCommandHandler : IRequestHandler<CreateReviewFeedbackCommand, CreatedReviewFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
        private readonly ReviewFeedbackBusinessRules _reviewFeedbackBusinessRules;

        public CreateReviewFeedbackCommandHandler(IMapper mapper, IReviewFeedbackRepository reviewFeedbackRepository,
                                         ReviewFeedbackBusinessRules reviewFeedbackBusinessRules)
        {
            _mapper = mapper;
            _reviewFeedbackRepository = reviewFeedbackRepository;
            _reviewFeedbackBusinessRules = reviewFeedbackBusinessRules;
        }

        public async Task<CreatedReviewFeedbackResponse> Handle(CreateReviewFeedbackCommand request, CancellationToken cancellationToken)
        {
            ReviewFeedback reviewFeedback = _mapper.Map<ReviewFeedback>(request);

            await _reviewFeedbackRepository.AddAsync(reviewFeedback);

            CreatedReviewFeedbackResponse response = _mapper.Map<CreatedReviewFeedbackResponse>(reviewFeedback);
            return response;
        }
    }
}