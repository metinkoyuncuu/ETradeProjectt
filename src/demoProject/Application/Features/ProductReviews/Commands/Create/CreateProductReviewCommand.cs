using Application.Features.ProductReviews.Constants;
using Application.Features.ProductReviews.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductReviews.Constants.ProductReviewsOperationClaims;

namespace Application.Features.ProductReviews.Commands.Create;

public class CreateProductReviewCommand : IRequest<CreatedProductReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public float Rate { get; set; }
    public string Comment { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductReviewsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductReviews";

    public class CreateProductReviewCommandHandler : IRequestHandler<CreateProductReviewCommand, CreatedProductReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly ProductReviewBusinessRules _productReviewBusinessRules;

        public CreateProductReviewCommandHandler(IMapper mapper, IProductReviewRepository productReviewRepository,
                                         ProductReviewBusinessRules productReviewBusinessRules)
        {
            _mapper = mapper;
            _productReviewRepository = productReviewRepository;
            _productReviewBusinessRules = productReviewBusinessRules;
        }

        public async Task<CreatedProductReviewResponse> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
        {
            ProductReview productReview = _mapper.Map<ProductReview>(request);

            await _productReviewRepository.AddAsync(productReview);

            CreatedProductReviewResponse response = _mapper.Map<CreatedProductReviewResponse>(productReview);
            return response;
        }
    }
}