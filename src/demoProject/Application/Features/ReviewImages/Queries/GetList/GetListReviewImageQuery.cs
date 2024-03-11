using Application.Features.ReviewImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ReviewImages.Constants.ReviewImagesOperationClaims;

namespace Application.Features.ReviewImages.Queries.GetList;

public class GetListReviewImageQuery : IRequest<GetListResponse<GetListReviewImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListReviewImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetReviewImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListReviewImageQueryHandler : IRequestHandler<GetListReviewImageQuery, GetListResponse<GetListReviewImageListItemDto>>
    {
        private readonly IReviewImageRepository _reviewImageRepository;
        private readonly IMapper _mapper;

        public GetListReviewImageQueryHandler(IReviewImageRepository reviewImageRepository, IMapper mapper)
        {
            _reviewImageRepository = reviewImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListReviewImageListItemDto>> Handle(GetListReviewImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ReviewImage> reviewImages = await _reviewImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListReviewImageListItemDto> response = _mapper.Map<GetListResponse<GetListReviewImageListItemDto>>(reviewImages);
            return response;
        }
    }
}