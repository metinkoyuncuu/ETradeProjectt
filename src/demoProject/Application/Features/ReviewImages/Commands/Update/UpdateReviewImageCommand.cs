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

namespace Application.Features.ReviewImages.Commands.Update;

public class UpdateReviewImageCommand : IRequest<UpdatedReviewImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewImagesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewImages";

    public class UpdateReviewImageCommandHandler : IRequestHandler<UpdateReviewImageCommand, UpdatedReviewImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewImageRepository _reviewImageRepository;
        private readonly ReviewImageBusinessRules _reviewImageBusinessRules;

        public UpdateReviewImageCommandHandler(IMapper mapper, IReviewImageRepository reviewImageRepository,
                                         ReviewImageBusinessRules reviewImageBusinessRules)
        {
            _mapper = mapper;
            _reviewImageRepository = reviewImageRepository;
            _reviewImageBusinessRules = reviewImageBusinessRules;
        }

        public async Task<UpdatedReviewImageResponse> Handle(UpdateReviewImageCommand request, CancellationToken cancellationToken)
        {
            ReviewImage? reviewImage = await _reviewImageRepository.GetAsync(predicate: ri => ri.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewImageBusinessRules.ReviewImageShouldExistWhenSelected(reviewImage);
            reviewImage = _mapper.Map(request, reviewImage);

            await _reviewImageRepository.UpdateAsync(reviewImage!);

            UpdatedReviewImageResponse response = _mapper.Map<UpdatedReviewImageResponse>(reviewImage);
            return response;
        }
    }
}