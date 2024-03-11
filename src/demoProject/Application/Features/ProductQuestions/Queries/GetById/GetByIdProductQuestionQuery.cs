using Application.Features.ProductQuestions.Constants;
using Application.Features.ProductQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductQuestions.Constants.ProductQuestionsOperationClaims;

namespace Application.Features.ProductQuestions.Queries.GetById;

public class GetByIdProductQuestionQuery : IRequest<GetByIdProductQuestionResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductQuestionQueryHandler : IRequestHandler<GetByIdProductQuestionQuery, GetByIdProductQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly ProductQuestionBusinessRules _productQuestionBusinessRules;

        public GetByIdProductQuestionQueryHandler(IMapper mapper, IProductQuestionRepository productQuestionRepository, ProductQuestionBusinessRules productQuestionBusinessRules)
        {
            _mapper = mapper;
            _productQuestionRepository = productQuestionRepository;
            _productQuestionBusinessRules = productQuestionBusinessRules;
        }

        public async Task<GetByIdProductQuestionResponse> Handle(GetByIdProductQuestionQuery request, CancellationToken cancellationToken)
        {
            ProductQuestion? productQuestion = await _productQuestionRepository.GetAsync(predicate: pq => pq.Id == request.Id, cancellationToken: cancellationToken);
            await _productQuestionBusinessRules.ProductQuestionShouldExistWhenSelected(productQuestion);

            GetByIdProductQuestionResponse response = _mapper.Map<GetByIdProductQuestionResponse>(productQuestion);
            return response;
        }
    }
}