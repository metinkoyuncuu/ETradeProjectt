using Application.Features.ProductQuestions.Constants;
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

namespace Application.Features.ProductQuestions.Commands.Delete;

public class DeleteProductQuestionCommand : IRequest<DeletedProductQuestionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductQuestionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductQuestions";

    public class DeleteProductQuestionCommandHandler : IRequestHandler<DeleteProductQuestionCommand, DeletedProductQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly ProductQuestionBusinessRules _productQuestionBusinessRules;

        public DeleteProductQuestionCommandHandler(IMapper mapper, IProductQuestionRepository productQuestionRepository,
                                         ProductQuestionBusinessRules productQuestionBusinessRules)
        {
            _mapper = mapper;
            _productQuestionRepository = productQuestionRepository;
            _productQuestionBusinessRules = productQuestionBusinessRules;
        }

        public async Task<DeletedProductQuestionResponse> Handle(DeleteProductQuestionCommand request, CancellationToken cancellationToken)
        {
            ProductQuestion? productQuestion = await _productQuestionRepository.GetAsync(predicate: pq => pq.Id == request.Id, cancellationToken: cancellationToken);
            await _productQuestionBusinessRules.ProductQuestionShouldExistWhenSelected(productQuestion);

            await _productQuestionRepository.DeleteAsync(productQuestion!);

            DeletedProductQuestionResponse response = _mapper.Map<DeletedProductQuestionResponse>(productQuestion);
            return response;
        }
    }
}