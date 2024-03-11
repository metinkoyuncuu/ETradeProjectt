using Application.Features.ProductQuestions.Constants;
using Application.Features.ProductQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductQuestions.Constants.ProductQuestionsOperationClaims;

namespace Application.Features.ProductQuestions.Commands.Create;

public class CreateProductQuestionCommand : IRequest<CreatedProductQuestionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductQuestionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductQuestions";

    public class CreateProductQuestionCommandHandler : IRequestHandler<CreateProductQuestionCommand, CreatedProductQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly ProductQuestionBusinessRules _productQuestionBusinessRules;

        public CreateProductQuestionCommandHandler(IMapper mapper, IProductQuestionRepository productQuestionRepository,
                                         ProductQuestionBusinessRules productQuestionBusinessRules)
        {
            _mapper = mapper;
            _productQuestionRepository = productQuestionRepository;
            _productQuestionBusinessRules = productQuestionBusinessRules;
        }

        public async Task<CreatedProductQuestionResponse> Handle(CreateProductQuestionCommand request, CancellationToken cancellationToken)
        {
            ProductQuestion productQuestion = _mapper.Map<ProductQuestion>(request);

            await _productQuestionRepository.AddAsync(productQuestion);

            CreatedProductQuestionResponse response = _mapper.Map<CreatedProductQuestionResponse>(productQuestion);
            return response;
        }
    }
}