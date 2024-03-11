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

namespace Application.Features.ProductQuestions.Commands.Update;

public class UpdateProductQuestionCommand : IRequest<UpdatedProductQuestionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductQuestionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductQuestions";

    public class UpdateProductQuestionCommandHandler : IRequestHandler<UpdateProductQuestionCommand, UpdatedProductQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly ProductQuestionBusinessRules _productQuestionBusinessRules;

        public UpdateProductQuestionCommandHandler(IMapper mapper, IProductQuestionRepository productQuestionRepository,
                                         ProductQuestionBusinessRules productQuestionBusinessRules)
        {
            _mapper = mapper;
            _productQuestionRepository = productQuestionRepository;
            _productQuestionBusinessRules = productQuestionBusinessRules;
        }

        public async Task<UpdatedProductQuestionResponse> Handle(UpdateProductQuestionCommand request, CancellationToken cancellationToken)
        {
            ProductQuestion? productQuestion = await _productQuestionRepository.GetAsync(predicate: pq => pq.Id == request.Id, cancellationToken: cancellationToken);
            await _productQuestionBusinessRules.ProductQuestionShouldExistWhenSelected(productQuestion);
            productQuestion = _mapper.Map(request, productQuestion);

            await _productQuestionRepository.UpdateAsync(productQuestion!);

            UpdatedProductQuestionResponse response = _mapper.Map<UpdatedProductQuestionResponse>(productQuestion);
            return response;
        }
    }
}