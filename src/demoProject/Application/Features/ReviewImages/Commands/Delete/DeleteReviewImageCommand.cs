using Application.Features.ReviewImages.Constants;
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

namespace Application.Features.ReviewImages.Commands.Delete;

public class DeleteReviewImageCommand : IRequest<DeletedReviewImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ReviewImagesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetReviewImages";

    public class DeleteReviewImageCommandHandler : IRequestHandler<DeleteReviewImageCommand, DeletedReviewImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewImageRepository _reviewImageRepository;
        private readonly ReviewImageBusinessRules _reviewImageBusinessRules;

        public DeleteReviewImageCommandHandler(IMapper mapper, IReviewImageRepository reviewImageRepository,
                                         ReviewImageBusinessRules reviewImageBusinessRules)
        {
            _mapper = mapper;
            _reviewImageRepository = reviewImageRepository;
            _reviewImageBusinessRules = reviewImageBusinessRules;
        }

        public async Task<DeletedReviewImageResponse> Handle(DeleteReviewImageCommand request, CancellationToken cancellationToken)
        {
            ReviewImage? reviewImage = await _reviewImageRepository.GetAsync(predicate: ri => ri.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewImageBusinessRules.ReviewImageShouldExistWhenSelected(reviewImage);

            await _reviewImageRepository.DeleteAsync(reviewImage!);

            DeletedReviewImageResponse response = _mapper.Map<DeletedReviewImageResponse>(reviewImage);
            return response;
        }
    }
}