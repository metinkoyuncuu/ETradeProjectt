using Application.Features.ReviewImages.Constants;
using Application.Features.ReviewImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ReviewImages.Constants.ReviewImagesOperationClaims;

namespace Application.Features.ReviewImages.Queries.GetById;

public class GetByIdReviewImageQuery : IRequest<GetByIdReviewImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdReviewImageQueryHandler : IRequestHandler<GetByIdReviewImageQuery, GetByIdReviewImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReviewImageRepository _reviewImageRepository;
        private readonly ReviewImageBusinessRules _reviewImageBusinessRules;

        public GetByIdReviewImageQueryHandler(IMapper mapper, IReviewImageRepository reviewImageRepository, ReviewImageBusinessRules reviewImageBusinessRules)
        {
            _mapper = mapper;
            _reviewImageRepository = reviewImageRepository;
            _reviewImageBusinessRules = reviewImageBusinessRules;
        }

        public async Task<GetByIdReviewImageResponse> Handle(GetByIdReviewImageQuery request, CancellationToken cancellationToken)
        {
            ReviewImage? reviewImage = await _reviewImageRepository.GetAsync(predicate: ri => ri.Id == request.Id, cancellationToken: cancellationToken);
            await _reviewImageBusinessRules.ReviewImageShouldExistWhenSelected(reviewImage);

            GetByIdReviewImageResponse response = _mapper.Map<GetByIdReviewImageResponse>(reviewImage);
            return response;
        }
    }
}