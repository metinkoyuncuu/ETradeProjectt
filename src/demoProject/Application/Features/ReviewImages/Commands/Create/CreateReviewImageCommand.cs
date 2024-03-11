using Application.Features.ReviewImages.Constants;
using Application.Features.ReviewImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ReviewImages.Constants.ReviewImagesOperationClaims;

namespace Application.Features.ReviewImages.Commands.Create;

public class CreateReviewImageCommand : IRequest<CreatedReviewImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewImagesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewImages";

    public class CreateReviewImageCommandHandler : IRequestHandler<CreateReviewImageCommand, CreatedReviewImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewImageRepository _reviewImageRepository;
        private readonly ReviewImageBusinessRules _reviewImageBusinessRules;

        public CreateReviewImageCommandHandler(IMapper mapper, IReviewImageRepository reviewImageRepository,
                                         ReviewImageBusinessRules reviewImageBusinessRules)
        {
            _mapper = mapper;
            _reviewImageRepository = reviewImageRepository;
            _reviewImageBusinessRules = reviewImageBusinessRules;
        }

        public async Task<CreatedReviewImageResponse> Handle(CreateReviewImageCommand request, CancellationToken cancellationToken)
        {
            ReviewImage reviewImage = _mapper.Map<ReviewImage>(request);

            await _reviewImageRepository.AddAsync(reviewImage);

            CreatedReviewImageResponse response = _mapper.Map<CreatedReviewImageResponse>(reviewImage);
            return response;
        }
    }
}